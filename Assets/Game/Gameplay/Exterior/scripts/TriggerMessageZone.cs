using UnityEngine;

public class TriggerMessageZone : MonoBehaviour
{
    [SerializeField] private FloatingMessageController uiController;
    [SerializeField, TextArea] private string messageToShow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiController.SetMessage(messageToShow);
        }
    }
}
