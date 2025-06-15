using System;
using System.Collections;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer = default;
    [SerializeField] private float winAnimationExtraTime = 0f;

    [SerializeField] private float radius = 0f;
    [SerializeField] private int spawnCount = 0;
    [SerializeField] private float spawnDelay = 0f;
    [SerializeField] private GameObject[] chibiPrefabs = null;

    private Action onFinishGame = null;
    private Action onWinAnimationEnd = null;

    public void Init(Action onFinishGame, Action onWinAnimationEnd)
    {
        this.onFinishGame = onFinishGame;
        this.onWinAnimationEnd = onWinAnimationEnd;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Utils.CheckLayerInMask(playerLayer, other.gameObject.layer))
        {
            DisablePlayerControls(other.gameObject);
            onFinishGame?.Invoke();
            PlayWinAnimation();
        }
    }

    private void DisablePlayerControls(GameObject player)
    {
        // Deshabilitar scripts de control del jugador
        var playerController = player.GetComponent<PlayerController>(); // Cambia "PlayerController" por el script que controla al jugador
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        // Deshabilitar scripts de control de la cámara (si es necesario)
        var cameraController = Camera.main.GetComponent<CameraController>(); // Cambia "CameraController" por el script que controla la cámara
        if (cameraController != null)
        {
            cameraController.enabled = false;
        }
    }

    public void PlayWinAnimation()
    {
        StartCoroutine(WinAnimationCoroutine());

        IEnumerator WinAnimationCoroutine()
        {
            // Esperar el tiempo necesario para la animación de victoria
            yield return new WaitForSeconds(winAnimationExtraTime);

            // Generar chibis alrededor de la zona
            for (int i = 0; i < spawnCount; i++)
            {
                float angle = i * Mathf.PI * 2 / spawnCount;

                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;

                Vector3 spawnPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

                int randomIndex = UnityEngine.Random.Range(0, chibiPrefabs.Length);
                GameObject chibiGO = Instantiate(chibiPrefabs[randomIndex], transform);
                chibiGO.transform.position = spawnPosition;
                chibiGO.transform.forward = Vector3.back;

                yield return new WaitForSeconds(spawnDelay);
            }

            // Invocar el evento de fin de animación
            onWinAnimationEnd?.Invoke();
        }
    }
}
