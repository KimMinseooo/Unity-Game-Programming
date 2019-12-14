using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 300;

    public static int Life;
    public int startLife = 30;

    public static int Rounds;
    
    void Start() {
        money = startMoney;
        Life = startLife;

        Rounds = 0;
    }
}
