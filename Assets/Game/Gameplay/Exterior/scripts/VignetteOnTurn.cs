using UnityEngine;
using OculusSampleFramework;

public class VignetteOnTurn : MonoBehaviour
{
    public GameObject vignetteCanvas;
    public float vignetteDuration = 0.4f;
    private bool isTurning = false;

    void Update()
    {
        Vector2 rightStick;
        OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch, out rightStick);

        if (!isTurning && Mathf.Abs(rightStick.x) > 0.8f)
        {
            StartCoroutine(ActivateVignette());
        }
    }

    private IEnumerator ActivateVignette()
    {
        isTurning = true;
        vignetteCanvas.SetActive(true);
        yield return new WaitForSeconds(vignetteDuration);
        vignetteCanvas.SetActive(false);
        isTurning = false;
    }
}
