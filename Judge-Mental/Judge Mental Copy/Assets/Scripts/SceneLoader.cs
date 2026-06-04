using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   [SerializeField]  private string mainMenuSceneName = "MainMenu";

   public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
