using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int bulletDamage = 15;
    public GameObject deatheffect;
    public float explosionRadius = 0f;
    public void Seek(Transform _target) {
        target = _target;
    }
    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceFrame, Space.World);
        transform.LookAt(target);


    }

    void HitTarget() {
        GameObject effect = (GameObject)Instantiate(deatheffect, transform.position, transform.rotation);
            Destroy(effect, 5f);

        if (explosionRadius > 0)
        {
            Explode();
        }
        else {
            Damage(target);
        }
        
        Destroy(gameObject);
    }


    void Damage(Transform enemy) {

        Enemy en = enemy.GetComponent<Enemy>();


        if (en != null) {
            en.TakeDamage(bulletDamage);

        }
    }


    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        }
    }
}
