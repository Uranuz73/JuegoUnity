using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Transform enemyPrefab;
    public float countdownTime = 5f;
    private float countdown = 2f;

    public WaveClass[] waves;

    public Transform spawnPoint;
    private int WaveNumber = 0;

    public Text waveCountdownText;

    private void Update()
    {


        if (EnemiesAlive > 0) {

            return;
        }

        if (countdown <= 0) {
            StartCoroutine(SpawnWave());
            countdown = countdownTime;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:0.0}", countdown);

    }


    IEnumerator SpawnWave() {

        
        Stats.Rounds++;

        WaveClass wave = waves[WaveNumber];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);

            yield return new WaitForSeconds(1f / wave.rate);
        }

        WaveNumber++;


    }


    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
  