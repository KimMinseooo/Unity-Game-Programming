using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string MainMenuScene = "MainMenuScene";
    public GameObject ui;

    public void Toggle() {
        ui.SetActive( !ui.activeSelf);

        if(ui.activeSelf) {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
    }

    public void PauseClick() {
        Toggle();        
    }

    public void Retry () {
        Toggle();
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue() {
        Debug.Log("Retry!");
        Toggle();
    }

    public void Menu() {
        Debug.Log("go to menu");
        SceneManager.LoadScene(MainMenuScene);
    }
}
