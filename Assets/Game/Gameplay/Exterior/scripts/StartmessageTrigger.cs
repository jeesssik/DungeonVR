using UnityEngine;

public class InitialMessage : MonoBehaviour
{
    [SerializeField] private FloatingMessageController uiController;
    [SerializeField, TextArea] private string initialMessage = "La espada está detrás de los tres tótems...";

    private void Start()
    {
        uiController.SetMessage(initialMessage);
    }
}
