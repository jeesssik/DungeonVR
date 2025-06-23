using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    public GameObject sword;
    public bool hasSword = false;

    public void HideSword()
    {
        Debug.Log("HideSword ejecutado");
        hasSword = true;
        if (sword != null)
        {
            sword.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Sword no asignado en el inspector.");
        }
    }
}
