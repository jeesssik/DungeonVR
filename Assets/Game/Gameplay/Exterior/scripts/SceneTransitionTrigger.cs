/*using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Dungeon";
    [SerializeField] private string loadingSceneName = "Loading";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Guardamos el nombre de la siguiente escena
            PlayerPrefs.SetString("NextScene", nextSceneName);
            SceneManager.LoadScene(loadingSceneName);
        }
    }
}*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Gameplay";
    // Ya no necesitas esta variable, pero la puedes dejar por si acaso
    //[SerializeField] private string loadingSceneName = "Loading";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Guardamos el nombre de la siguiente escena (opcional si no usas loading)
            PlayerPrefs.SetString("NextScene", nextSceneName);
            // Cargar directamente la escena de gameplay
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
