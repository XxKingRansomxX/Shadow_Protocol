using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettingsScene : MonoBehaviour
{
    public Button backButton; // Assign this in the Inspector

    void Start()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(ReturnToMainMenu);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your actual main menu scene name if different
    }

    void Update()
    { 
    
    }
        
}
