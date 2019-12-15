using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    void OnEnable() {
        roundsText.text = "SCORE : " + PlayerStats.Score.ToString();
    }
}
