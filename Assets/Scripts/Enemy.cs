using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // 유닛 초기 속도
    public float startSpeed = 10f;
    public float speed;
    // 유닛 초기 체력
    public float startHealth = 100;
    private float Health;
    // 유닛 가격
    public int coin = 100;


    // Start is called before the first frame update
    void Start()
    {
        // 초기값 설정.
        speed = startSpeed;
        Health = startHealth;
    }

    // 유닛 데미지 함수
    public void TakeDamage() {
        PlayerStats.money += coin;
        Destroy(gameObject);

    }
}
