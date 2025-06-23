using UnityEngine;

public class TriggerMessageZone : MonoBehaviour
{
    [SerializeField] private FloatingMessageController uiController;

    [Header("Mensajes")]
    [SerializeField, TextArea] private string messageWithoutSword = "La barrera es impenetrable... encuentra la espada.";
    [SerializeField, TextArea] private string messageWithSword = "El poder te acompaña. Dirígete al puente del castillo.";

    [Header("Referencia a la espada")]
    [SerializeField] private SwordPickup swordPickup;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (swordPickup != null && swordPickup.hasSword)
            {
                uiController.SetMessage(messageWithSword);
            }
            else
            {
                uiController.SetMessage(messageWithoutSword);
            }
        }
    }
}
