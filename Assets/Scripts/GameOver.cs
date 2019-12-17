using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    void OnEnable() {
        roundsText.text = "SCORE : " + PlayerStats.Score.ToString();
    }

    public void Retry() {
        Time.timeScale = 1f;
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
}
