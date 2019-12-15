using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 300;

    public static int Life;
    public int startLife = 30;

    public static int Score;
    
    void Start() {
        money = startMoney;
        Life = startLife;

        Score = 0;
    }
}
