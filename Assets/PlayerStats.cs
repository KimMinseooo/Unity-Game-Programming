using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 300;
    
    void Start() {
        money = startMoney;
    }
}
