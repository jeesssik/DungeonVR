using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerCameraRoot; // Este es el GameObject que representa la cabeza del jugador
    public Vector3 offset = new Vector3(0f, 0f, -4f); // Posición detrás del jugador
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (playerCameraRoot == null) return;

        // Calcula la posición deseada en base a la rotación del jugador
        Vector3 desiredPosition = playerCameraRoot.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // La cámara mira hacia el punto que ve el jugador (podés ajustar si querés un poco más arriba o abajo)
        transform.LookAt(playerCameraRoot);
    }
}
