using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInputManager : MonoBehaviour
{
   

    void Update()
    {
        // Quit game on ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        // Toggle menu on F1
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // If you want to load the main menu scene on F1:
            SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your actual main menu scene name if different

            // If you still want to toggle a menu panel instead, comment out the above line and uncomment below:
            /*
            if (menuPanel != null)
            {
                isMenuOpen = !isMenuOpen;
                menuPanel.SetActive(isMenuOpen);
            }
            */
        }
    }
}