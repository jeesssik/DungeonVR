using UnityEngine;
using UnityEngine.InputSystem;

public class MessageInputHandler : MonoBehaviour
{
    [SerializeField] private FloatingMessageController uiController;

    void Update()
    {
        // Meta Quest: botón A del control derecho
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Debug.Log("Presionaste A");
            uiController.ShowLastMessage();
        }
    }
}
