using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static bool gameIsOVer;

    public GameObject gameOverUI;

    void Start() {
        gameIsOVer = false;
    }

    void Update() {
        if(gameIsOVer) {
            return ;
        }

        if(Input.GetKeyDown("e")) {
            EndGame();
        }

        if(PlayerStats.Life <= 0) {
            EndGame();
        }
    }

    void EndGame() {
        gameIsOVer = true;
        gameOverUI.SetActive(true);
    }
}
