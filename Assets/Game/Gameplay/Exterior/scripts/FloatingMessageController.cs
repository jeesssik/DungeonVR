using TMPro;
using UnityEngine;

public class FloatingMessageController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;

    private void Start()
    {
        SetMessage("🔍 Acertijo: La espada se esconde detrás de los 3 tótems...");
    }

    public void SetMessage(string newMessage)
    {
        messageText.text = newMessage;
    }
}
