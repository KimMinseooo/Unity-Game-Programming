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
    public Image healthBar;

    private bool isDead =false;
    // 유닛 가격
    public int coin = 100;

    public GameObject DamageText;
    public GameObject TextPos;



    
    // Start is called before the first frame update
    void Start()
    {
        // 초기값 설정.
        speed = startSpeed;
        Health = startHealth;
    }

    // 유닛 데미지 함수
    public void TakeDamage(float amount) {
        
        GameObject dmgText =Instantiate(DamageText, TextPos.transform.position, Quaternion.Euler(40,0,0));
        dmgText.GetComponent<Text>().text = amount.ToString();
        Destroy(dmgText, 1f); //1초 후 데미지 텍스트 삭제
        
        Health -=amount;

        healthBar.fillAmount = Health /startHealth;

        if(Health <= 0 && !isDead)
        {
        Die();
        }
    }

    void Die()
    {
        isDead =true;

        PlayerStats.money += coin;
        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}
