using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro
using UnityEngine.SceneManagement; //Library to manage scenes

public class SceneSelection : MonoBehaviour
{
    [Header("Selector escena")] //Works to have a header on Unity's inspector
    public string sceneToLoad;

    public void LoadScene() //Load scene by name
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        else
        {
            Debug.LogError("El nombre de la escena o la escena, no está configurado correctamente"); //Prints a message on the console
        }
    }

    public void LoadSceneIndex(int sceneIndex) //Load scene by index
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        else
        {
            Debug.LogError("El nombre de la escena o la escena, no está configurado correctamente"); //Prints a message on the console
        }
    }

    public void ExitProgram()
    {
        Debug.Log("El juego se cierra");
        Application.Quit();
    }
}
