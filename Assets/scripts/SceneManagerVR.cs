using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerVR : MonoBehaviour
{
    [Header("Canvases")]
    public GameObject MainMenuCanvas;
    public GameObject optionsCanvas;

    // Inicia el juego cargando la escena de juego principal
    public void StartGame()
    {
        SceneManager.LoadScene("EjemploUI");
    }

    // Muestra el menú de opciones y oculta el menú principal
    public void ShowOptions()
    {
        MainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    // Cierra la aplicación y muestra un mensaje de cierre
    public void QuitGame()
    {
        Debug.Log("La aplicación se cerró correctamente.");
        Application.Quit(); // esto sólo funciona cuando el juego es un .exe y no cuando se lo está probando desde Unity
    }

    public void BackToMainMenu()
    {
        optionsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }
}
