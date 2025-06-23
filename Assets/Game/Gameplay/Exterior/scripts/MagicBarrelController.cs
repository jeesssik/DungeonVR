/*

using UnityEngine;
using TMPro;

public class MagicBarrierController : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public SwordPickup swordPickup;
    public GameObject messagePanel;

    public string messageNoSword = "El sello ancestral impide el paso.";
    public float fadeDuration = 2f;

    private bool isFadingOut = false;
    private bool isPlayerInside = false;
    private bool messageVisible = false;

    public GameObject barrierRoot;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || isFadingOut) return;

        if (!swordPickup.hasSword)
        {
            isPlayerInside = true;
            ShowMessage(messageNoSword);
            messageVisible = true;
        }
        else
        {
            StartCoroutine(FadeOutBarrier());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        isPlayerInside = false;
        messageVisible = false;
        HideMessage();
    }

    private void Update()
    {
        if (isPlayerInside && !isFadingOut && Input.GetKeyDown(KeyCode.E))
        {
            messageVisible = !messageVisible;

            if (messageVisible)
                ShowMessage(messageNoSword);
            else
                HideMessage();
        }
    }

    private void ShowMessage(string msg)
    {
        if (messagePanel != null && messageText != null)
        {
            messagePanel.SetActive(true);
            messageText.text = msg;
        }
    }

    private void HideMessage()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
    }

    private System.Collections.IEnumerator FadeOutBarrier()
    {
        isFadingOut = true;

        Renderer rend = GetComponentInChildren<Renderer>();
        Material mat = rend.material;

        float t = 0f;
        Color startColor = mat.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            mat.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        //gameObject.SetActive(false);
        // transform.parent.gameObject.SetActive(false);
       barrierRoot.SetActive(false);

    }
}
*/


using UnityEngine;
using TMPro;

public class MagicBarrierController : MonoBehaviour
{
    [Header("Referencias UI")]
    public TextMeshProUGUI messageText;
    public GameObject messagePanel;

    [Header("Sword")]
    public SwordPickup swordPickup;

    [Header("Configuración de barrera")]
    public GameObject barrierRoot; // Asigná aquí el objeto padre que querés desactivar

    [TextArea]
    public string messageNoSword = "El sello ancestral impide el paso.";
    public float fadeDuration = 2f;

    private bool isFadingOut = false;
    private bool isPlayerInside = false;
    private bool messageVisible = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || isFadingOut) return;

        if (!swordPickup.hasSword)
        {
            isPlayerInside = true;
            ShowMessage(messageNoSword);
            messageVisible = true;
        }
        else
        {
            StartCoroutine(FadeOutBarrier());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        isPlayerInside = false;
        messageVisible = false;
        HideMessage();
    }

    private void Update()
    {
        // Opcional: permitir mostrar/ocultar el mensaje con "E" si el jugador no tiene la espada
        if (isPlayerInside && !isFadingOut && Input.GetKeyDown(KeyCode.E))
        {
            messageVisible = !messageVisible;

            if (messageVisible)
                ShowMessage(messageNoSword);
            else
                HideMessage();
        }
    }

    private void ShowMessage(string msg)
    {
        if (messagePanel != null && messageText != null)
        {
            messagePanel.SetActive(true);
            messageText.text = msg;
        }
    }

    private void HideMessage()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
    }

    private System.Collections.IEnumerator FadeOutBarrier()
    {
        isFadingOut = true;

        if (barrierRoot == null)
        {
            Debug.LogError("🛑 Falta asignar 'barrierRoot' en el inspector.");
            yield break;
        }

        Renderer rend = barrierRoot.GetComponentInChildren<Renderer>();
        if (rend == null)
        {
            Debug.LogError("🛑 No se encontró un Renderer en 'barrierRoot': " + barrierRoot.name);
            yield break;
        }

        Material mat = rend.material;
        Color startColor = mat.color;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            mat.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        barrierRoot.SetActive(false);
    }
}
