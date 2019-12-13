using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // 유닛 경로 탐색 배열
    private Transform target;
    // 유닛 경로 탐색 배열 인덱스
    private int wavepointIndex = 0;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        // enemy 객체
        enemy = GetComponent<Enemy>();

        // 경로 대상
        target = Waypoints.points[0];       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWayPoint();
        }
        
        enemy.speed = enemy.startSpeed;
    }

    void GetNextWayPoint() {
        
        if(wavepointIndex >= Waypoints.points.Length - 1) {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath() {
        PlayerStats.Life--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
