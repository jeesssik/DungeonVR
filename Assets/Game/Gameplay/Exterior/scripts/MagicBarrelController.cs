using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagicBarrierController : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public SwordPickup swordPickup;
    public GameObject messagePanel;
 

    public string messageNoSword = "El sello ancestral impide el paso.";
    public float fadeDuration = 2f;

    private bool isFadingOut = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || isFadingOut) return;

        if (!swordPickup.hasSword)
        {
            ShowMessage(messageNoSword);
        }
        else
        {
            StartCoroutine(FadeOutBarrier());
        }
    }

    private void ShowMessage(string msg)
    {
        messagePanel.SetActive(true);
        messageText.text = msg;
        Invoke(nameof(HideMessage), 3f);
    }

    private void HideMessage()
    {
        messagePanel.SetActive(false);
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

        gameObject.SetActive(false);
    }
}
