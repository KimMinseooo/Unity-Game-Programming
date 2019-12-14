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

    public GameObject coinText;
    public GameObject DamageText;
    public GameObject TextPos;

    public GameObject coinTextPos;


    
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
        //적기 사망시 coin 획득 텍스트 추가
        TextPos.transform.position=new Vector3(TextPos.transform.position.x,TextPos.transform.position.y+1,TextPos.transform.position.z);
        GameObject getcoinText =Instantiate(coinText, TextPos.transform.position,Quaternion.Euler(40,0,0));
        getcoinText.GetComponent<Text>().text = "$" +coin.ToString();
        Destroy(getcoinText, 1f); //1초 후 코인 획득 텍스트 삭제 
        isDead =true;

        PlayerStats.money += coin;
        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}
