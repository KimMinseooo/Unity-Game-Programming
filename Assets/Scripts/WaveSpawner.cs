using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int  EnemiesAlive = 0;

    // Unity Inspector 에서 size 를 지정 Element 별로
    // Wave 정보를 설정 가능.
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    
    private PlayerStats playerMoney;

    public Text waveCountdownText;

    private int waveIndex = 0;

    void Update() {
        if(EnemiesAlive > 0 ) {
            return ;
        }


        // countdown 이 0과 같거나 작을 때
        // 시간의 경과에 따른 실행
        if(countdown <= 0f) {
            StartCoroutine(SpawnWave());
            // ReSpawn 시간이 지금은 5초로 지정됨.
            countdown = timeBetweenWaves;
            return ;
        }

        // 시간을 계속해서 빼줌.
        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }
    
    IEnumerator SpawnWave() {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for(int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            // 1초마다 생성.
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
