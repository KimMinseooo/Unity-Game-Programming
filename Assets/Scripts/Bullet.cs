using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed  = 70f;
    public float explosionRadius = 0f;

    public int damage =50;
    public GameObject impactEffect;

    public void seek(Transform _target) {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {
            // 발사체가 대상을 잃으면 삭제.
            Destroy(gameObject);
            return ;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return ;
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    // 미사일 또는 투사체 Hit 계산
    void HitTarget() {
        GameObject effectIn = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIn, 5f);

        if(explosionRadius > 0f) {
            Explode();
        } else {
            Damage(target);
        }

        Destroy(gameObject);
    }

    // Splash Target 구하는 함수
    void Explode() {
       Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
       foreach (Collider collider in colliders) {
           if(collider.tag == "Enemy") {
               Damage(collider.transform);
           }
       }
    }

    // Target Damage 계산
    void Damage(Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy>();
        e.TakeDamage(damage);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
