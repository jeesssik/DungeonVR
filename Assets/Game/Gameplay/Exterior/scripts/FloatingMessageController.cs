/*using TMPro;
using UnityEngine;

public class FloatingMessageController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float autoHideDelay = 5f;

    private string lastMessage = "";

    private void Start()
    {
        SetMessage("Press A to see the last message", true);
        HideMessage();
    }

    public void SetMessage(string newMessage, bool autoHide = true)
    {
        lastMessage = newMessage;
        messageText.text = newMessage;
        ShowMessage();

        if (autoHide)
        {
            CancelInvoke();
            Invoke(nameof(HideMessage), autoHideDelay);
        }
    }

    public void ShowLastMessage()
    {
        if (!string.IsNullOrEmpty(lastMessage))
        {
            SetMessage(lastMessage, false);
        }
    }

    public void ShowMessage()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void HideMessage()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
*/

using TMPro;
using UnityEngine;

public class FloatingMessageController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float autoHideDelay = 5f;

    private string lastMessage = "";
    private bool isVisible = false;

    private void Start()
    {
        HideMessage(); // solo ocultamos, no seteamos mensaje inicial
    }

    public void SetMessage(string newMessage, bool autoHide = true)
    {
        lastMessage = newMessage;
        messageText.text = newMessage;
        ShowMessage();

        if (autoHide)
        {
            CancelInvoke();
            Invoke(nameof(HideMessage), autoHideDelay);
        }
    }

    public void ShowLastMessage()
    {
        if (!string.IsNullOrEmpty(lastMessage))
        {
            if (!isVisible)
            {
                messageText.text = lastMessage;
                ShowMessage();
            }
            else
            {
                HideMessage();
            }
        }
    }

    public void ShowMessage()
    {
        isVisible = true;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void HideMessage()
    {
        isVisible = false;
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}

