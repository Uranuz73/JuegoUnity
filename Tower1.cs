using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower1 : MonoBehaviour
{

    public Transform target;
    private Enemy targetEnemy;
    public string enemyTag = "Enemy";
    public Transform Turret;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Stats")]
    public float range = 15f;
    public float turnSpeed = 10f;
    public float fireRate = 0.2f;
    private float fireCountdown = 0.1f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy == null && shortestDistance >= range)
		{
            target = null;
        } else
		{
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
            
		}

	}

    void Update()
    {
        if (target == null) {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Turret.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Turret.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot() {

       GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null) {

            bullet.Seek(target);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
