    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsPanel;

    void Start()
    {
       
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
#endif
    }

    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene("SettingsScene"); // Use your actual scene name here
    }

    public void OpenCreditsMenu()
    {
        SceneManager.LoadScene("CreditsScene"); // Use your actual credits scene name
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Use your actual main menu scene name
    }

    void Update()
    {

    }
}
