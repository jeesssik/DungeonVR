using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    public GameObject sword;

    public void HideSword()
    {
        Debug.Log("HideSword ejecutado");
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
