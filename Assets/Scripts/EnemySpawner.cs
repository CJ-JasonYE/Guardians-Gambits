using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public static int CountEnemyAlive = 0;
    public Wave[] waves;
    public Transform START;
    public float waveRate = 1.5f;
    private Coroutine coroutine;
    private int infinityEnemy = 10;
    public BuiltTurretData BTD;
    //private bool isInfinityMode = false;

    void Start()
    {
        coroutine = StartCoroutine(SpawnEnemy());
    }
    public void Stop()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {

                BTD.AddEnemy(GameObject.Instantiate(wave.enemyPrefab, START.position, Quaternion.identity) as GameObject);
                CountEnemyAlive++;
                if(i!=wave.count-1)
                    yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
        //after all waves enemies dead
        //while (CountEnemyAlive > 0)
        //{
        //    yield return 0;
        //}
        //Change the mode to infinity mode
        //GameManager.Instance.Win();

        //isInfinityMode = true;
        while (true)
        {
            //Debug.Log($"Enemy counter: {infinityEnemy}");
            int random1 = Random.Range(0, infinityEnemy);
            int random2 = Random.Range(0, infinityEnemy - random1);
            int random3 = Random.Range(0, infinityEnemy - random1 - random2);
            int random4 = infinityEnemy - random1 - random2 - random3;
            for(int i = 0; i < random1; i++)
            {
                BTD.AddEnemy(GameObject.Instantiate(waves[0].enemyPrefab, START.position, Quaternion.identity) as GameObject);
                CountEnemyAlive++;
                yield return new WaitForSeconds(waves[0].rate);
            }
            for(int i = 0; i < random2; i++)
            {
                BTD.AddEnemy(GameObject.Instantiate(waves[1].enemyPrefab, START.position, Quaternion.identity) as GameObject);
                CountEnemyAlive++;
                yield return new WaitForSeconds(waves[1].rate);
            }
            for(int i = 0; i < random3; i++)
            {
                BTD.AddEnemy(GameObject.Instantiate(waves[2].enemyPrefab, START.position, Quaternion.identity) as GameObject);
                CountEnemyAlive++;
                yield return new WaitForSeconds(waves[2].rate);
            }
            for (int i = 0;i < random4; i++)
            {
                BTD.AddEnemy(GameObject.Instantiate(waves[3].enemyPrefab, START.position, Quaternion.identity) as GameObject);
                CountEnemyAlive++;
                yield return new WaitForSeconds(waves[3].rate);
            }
            while (CountEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
            infinityEnemy += (int)((int)infinityEnemy/3) * StaticData.EnemyCounterMultiplier;
        }
    }

}
