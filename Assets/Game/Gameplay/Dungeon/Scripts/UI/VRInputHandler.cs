using UnityEngine;
using UnityEngine.InputSystem;

public class VRInputHandler : MonoBehaviour
{
    [SerializeField] private GameplayUI gameplayUI;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();
        inputActions.Gameplay.Pause.performed += OnPausePressed;
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Pause.performed -= OnPausePressed;
        inputActions.Gameplay.Disable();
    }

    private void OnPausePressed(InputAction.CallbackContext context)
    {
        gameplayUI.TogglePause(true);
    }
}
