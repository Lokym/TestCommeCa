using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    // public Transform[] Spawn;
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;
    public Transform Spawn4;


    public EnemySpawnInfo[] Enemies;

    private bool Spawned;
    private int currentWave = 0;

    private int EnemyAlives = 0;
    private int EnemyAlives2 = 0;
    private Camera _Cam;


    // Use this for initialization
    void Start()
    {

        _Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() ;
    }

    private void Update()
    {
        Debug.Log(EnemyAlives);

        if (transform.position.x <= _Cam.transform.position.x  && !Spawned)
        {
            
            Spawned = true;

                StartCoroutine(SpawnEnemy1());
            StartCoroutine(SpawnEnemy2());

        }
    }
    

    IEnumerator SpawnEnemy1()
    {
        EnemySpawnInfo EnemyCount = Enemies[currentWave];

        for (int i = 0; i < EnemyCount.count; i++)
        {
            SpawnEnemies(EnemyCount.Enemy);
            yield return new WaitForSeconds(1 / EnemyCount.rate);

        }
    }

    IEnumerator SpawnEnemy2()
    {
        EnemySpawnInfo EnemyCount = Enemies[currentWave];

        for (int i = 0; i < EnemyCount.count2; i++)
        {

            SpawnEnemy2(EnemyCount.Enemy2);
            yield return new WaitForSeconds(1 / EnemyCount.rate2);
        }

    }

    void SpawnEnemies(GameObject Enemy)
    {
        Instantiate(Enemy, new Vector3(Spawn1.transform.position.x, Spawn1.transform.position.y), Spawn1.transform.rotation);
        EnemyAlives++;
    }

    void SpawnEnemy2(GameObject Enemy)
    {
        Instantiate(Enemy, new Vector3(Spawn2.transform.position.x, Spawn2.transform.position.y), Spawn2.transform.rotation);
        EnemyAlives2++;

    }

}
