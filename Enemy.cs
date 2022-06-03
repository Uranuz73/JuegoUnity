using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float StartHealth = 10f;
    private float health;

    private Transform target;
    private int wavepointIndex = 0;
    private Vector3 enemySize = new Vector3(1f, 1f, 1f);
    public int reward = 15;

    public Image healthBar;

    public GameObject deathEffect;
    private void Start()
    {
        transform.localScale = enemySize;
        target = WaypointsScript.points[0];
        health = StartHealth;
    }

    private void Update()
    {

        Vector3 direction = target.position - transform.position;

        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWaypoint();
        }
    }



    public void TakeDamage(int damage)
    {
        StartHealth -= damage;

        healthBar.fillAmount = StartHealth / health;
        healthBar.fillAmount = .5f;

        if (StartHealth <= 0) {

            Die();
        }


    }

    public void Die() {
        Stats.Money += reward;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);

        WaveSpawner.EnemiesAlive--;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= WaypointsScript.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = WaypointsScript.points[wavepointIndex];
    }

    void EndPath()
    {
        Stats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
