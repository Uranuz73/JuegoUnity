using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public float countdownTime = 5f;
    private float countdown = 2f;
    public GameMaster gameMaster;

    public WaveClass[] waves;

    public Transform spawnPoint;
    private int WaveNumber = 0;

    public Text waveCountdownText;

    private void Update()
    {


        if (EnemiesAlive > 0) {

            return;
        }

        Debug.Log(WaveNumber + "a");
        Debug.Log(waves.Length + "b");




        if (countdown <= 0f) {
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



        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count ; i++)
        {

            SpawnEnemy(wave.enemy);

            yield return new WaitForSeconds(1f / wave.rate);

            
        }


        WaveNumber++;

        if (WaveNumber == waves.Length)
        {

            gameMaster.WinLevel();
            this.enabled = false;
        }

    }


    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
  