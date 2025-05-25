using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, IDamagable
{
    [Header("General Settings")]
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private int maxLife = 100;
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 4f;
    [SerializeField] private float defenseSpeed = 1f;
    [SerializeField] private float turnSmoothVelocity = 5f;
    [SerializeField] private float aimRotationTime = 0.2f;

    [Header("Inventory & Interaction")]
    [SerializeField] private PlayerInventoryController inventoryController;
    [SerializeField] private PlayerItemInteraction itemInteraction;
    [SerializeField] private PickItem pickItem;

    [Header("Audio Events")]
    [SerializeField] private AudioEvent deathSound;
    [SerializeField] private AudioEvent recieveHitSound;
    [SerializeField] private AudioEvent pickUpSound;

    [Header("Mouse Look Settings")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float verticalRotationLimit = 80f;

    // Internals
    private PlayerInputController inputController;
    private CharacterController character;
    private Animator anim;
    private Coroutine aimRotationCoroutine;

    private Vector3 direction = Vector3.zero;
    private float velocityY = 0f;
    private float currentSpeed;
    private float cameraPitch = 0f;
    private float verticalRotation = 0f;
    private int currentLife;
    private bool isDefending = false;
    private bool isDead = false;

    // Delegates
    private Action onOpenPausePanel;
    private Action<int, int> onUpdateLife;
    private Action onPlayerDeath;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        inputController = GetComponent<PlayerInputController>();
    }

    private void Start()
    {
        currentSpeed = walkSpeed;
        currentLife = maxLife;

        inputController.Init(
            ToggleOnPause,
            ToggleInventory,
            PickItem,
            ToggleRun,
            inventoryController.ChangeWeapons,
            itemInteraction.PressAction1,
            itemInteraction.PressAction2,
            itemInteraction.CancelAction1,
            itemInteraction.CancelAction2
        );

        inventoryController.Init();
        itemInteraction.Init(inputController, inventoryController, ToggleDefense, ConsumePotionLife, LookMousePosition);
    }

    private void Update()
    {
        ApplyGravity();
        HandleCameraRotation();
        HandleBodyRotation();
        MovePlayer();
        HandleMouseLook(); // Solo si usás Input.GetAxis
        UpdateAnimation();
    }

    public void Init(Action onOpenPausePanel, Action<int, int> onUpdateLife, Action onPlayerDeath)
    {
        this.onOpenPausePanel = onOpenPausePanel;
        this.onUpdateLife = onUpdateLife;
        this.onPlayerDeath = onPlayerDeath;
    }

    public void ResetPlayer(Vector3 resetPosition)
    {
        character.enabled = false;
        bodyTransform.SetPositionAndRotation(resetPosition, Quaternion.identity);
        character.enabled = true;
    }

    private void ApplyGravity()
    {
        velocityY = character.isGrounded ? 0f : -Physics.gravity.magnitude;
    }
    
        private void HandleBodyRotation()
        {
            Vector2 move = inputController.Move;

            if (move.sqrMagnitude > 0.01f)
            {
                Vector3 direction = new Vector3(move.x, 0, move.y);
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                bodyTransform.rotation = Quaternion.Slerp(bodyTransform.rotation, targetRotation, turnSmoothVelocity * Time.deltaTime);
            }
        }
   


    private void MovePlayer()
    {
        Vector3 moveInput = new Vector3(inputController.Move.x, 0f, inputController.Move.y).normalized;
        Vector3 moveDir = bodyTransform.TransformDirection(moveInput);
        moveDir.y = velocityY;
        character.Move(currentSpeed * Time.deltaTime * moveDir);
    }

    private void HandleCameraRotation()
    {
        Vector2 lookInput = inputController.Look;

        cameraPitch -= lookInput.y * mouseSensitivity * Time.deltaTime;
        cameraPitch = Mathf.Clamp(cameraPitch, -verticalRotationLimit, verticalRotationLimit);
        cameraTransform.localEulerAngles = new Vector3(cameraPitch, 0, 0);

        bodyTransform.Rotate(Vector3.up * lookInput.x * mouseSensitivity * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        bodyTransform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        cameraPivot.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    private void UpdateAnimation()
    {
        anim.SetFloat("Speed", GetNormalizedSpeed(), 0.05f, Time.deltaTime);
    }

    private float GetNormalizedSpeed()
    {
        float inputMagnitude = Mathf.Clamp01(Mathf.Abs(inputController.Move.x) + Mathf.Abs(inputController.Move.y));
        float maxSpeed = isDefending ? defenseSpeed : runSpeed;
        return inputMagnitude * currentSpeed / maxSpeed;
    }

    private void ToggleRun(bool status)
    {
        currentSpeed = status ? runSpeed : walkSpeed;
    }

    private void ToggleDefense(bool status)
    {
        isDefending = status;
        currentSpeed = status ? defenseSpeed : walkSpeed;
    }

    private void PickItem()
    {
        ItemData item = pickItem.GetClosestItem();
        if (item != null)
        {
            anim.SetTrigger("PickUp");
            inventoryController.AddNewItem(item);
            pickItem.RemoveDestroyItem(item);
            GameManager.Instance.AudioManager.PlayAudio(pickUpSound);
            Destroy(item.gameObject);
        }
    }

    private void ToggleInventory()
    {
        inventoryController.ToggleInventory();
        inputController.UpdateInputFSM(inventoryController.IsOpenPanelInventory() ? FSM_INPUT.INVENTORY : FSM_INPUT.ENABLE_ALL);
    }

    private void ToggleOnPause()
    {
        TogglePause(true);
        onOpenPausePanel?.Invoke();
    }

    public void TogglePause(bool status)
    {
        inputController.UpdateInputFSM(status ? FSM_INPUT.ONLY_UI : inputController.CurrentInputState, false);
    }

    public void DisableInput()
    {
        inputController.UpdateInputFSM(FSM_INPUT.ONLY_UI);
    }

    public void PlayVictoryAnimation()
    {
        anim.Play("Victory");
    }

    private void LookMousePosition(Vector3 mousePosition)
    {
        if (aimRotationCoroutine != null)
            StopCoroutine(aimRotationCoroutine);

        Vector3 direction = (mousePosition - bodyTransform.position).normalized;
        direction.y = 0f;

        aimRotationCoroutine = StartCoroutine(RotateTowards(Quaternion.LookRotation(direction)));
    }
/////////////////////////////
    /* private IEnumerator RotateTowards(Quaternion targetRotation)
     {
         float timer = 0f;
         Quaternion startRotation = bodyTransform.rotation;

         while (timer < aimRotationTime)
         {
             timer += Time.deltaTime;
             bodyTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, timer / aimRotationTime);
             yield return null;
         }

         bodyTransform.rotation = targetRotation;
     }*/
    //////////////////////////////////
  
private IEnumerator RotateTowards(Quaternion targetRotation)
{
    float timer = 0f;
    Quaternion startRotation = bodyTransform.rotation;

    // Forzar la rotación solo en Y
    Vector3 eulerTarget = targetRotation.eulerAngles;
    Quaternion targetRotationY = Quaternion.Euler(0, eulerTarget.y, 0);

    while (timer < aimRotationTime)
    {
        timer += Time.deltaTime;
        bodyTransform.rotation = Quaternion.Lerp(startRotation, targetRotationY, timer / aimRotationTime);
        yield return null;
    }

    bodyTransform.rotation = targetRotationY;
}



    /// ////////////////////////////////////////////////

    private void ConsumePotionLife(int life)
    {
        currentLife = Mathf.Clamp(currentLife + life, 0, maxLife);
        onUpdateLife?.Invoke(currentLife, maxLife);
    }

    public void Damage(int amount)
    {
        if (isDead) return;

        currentLife -= amount;
        currentLife = Mathf.Max(0, currentLife);

        if (currentLife == 0)
        {
            Death();
        }
        else
        {
            GameManager.Instance.AudioManager.PlayAudio(recieveHitSound);
            onUpdateLife?.Invoke(currentLife, maxLife);
        }
    }

    private void Death()
    {
        isDead = true;
        inputController.UpdateInputFSM(FSM_INPUT.ONLY_UI);
        anim.Play("Die");
        GameManager.Instance.AudioManager.PlayAudio(deathSound);
        onPlayerDeath?.Invoke();
    }
}
