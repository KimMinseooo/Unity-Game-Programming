using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string MainScene = "MainScenes";
    public GameObject ui;

    public void infoToggle() {
        ui.SetActive( !ui.activeSelf );
    }

    public void Play() {
        SceneManager.LoadScene(MainScene);
    }

    public void Exit() {
        Application.Quit();
    }

    public void Infomation() {
        infoToggle();
    }

    public void infoClose() {
        infoToggle();
    }
}
