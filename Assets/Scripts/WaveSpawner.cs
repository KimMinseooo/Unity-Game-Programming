﻿using System.Collections;
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

    private float timeBetweenWaves = 15f;
    private float waveTime = 60f;
    private float countdown = 2f;
    private bool isWaveTime = true;
    
    private PlayerStats playerMoney;

    public Text waveCountdownText;

    private int waveIndex = 0;

    void Start() {
        EnemiesAlive = 0;
    }

    void Update() {
        // 시간을 계속해서 빼줌.
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();

        // countdown 이 0과 같거나 작을 때
        // 시간의 경과에 따른 실행
        if(countdown <= 0f && isWaveTime) {
            StartCoroutine(SpawnWave());
            countdown = waveTime;
            isWaveTime = false;
            return ;
        } else if(countdown <= 0f && !isWaveTime) {
            WaveEnd();
            countdown = timeBetweenWaves;
            isWaveTime = true;
            return ;
        }
    }

    IEnumerator SpawnWave() {
        Wave wave = waves[0];

        for(int i = 0; i < wave.GetCount(); i++) {
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

    void WaveEnd() {
        if(PlayerStats.Life <= 0) {
            GameMaster.gameIsOVer = true;
        }

        if(EnemiesAlive > 0 ) {
            PlayerStats.Life -= EnemiesAlive;
        }

    }
}
