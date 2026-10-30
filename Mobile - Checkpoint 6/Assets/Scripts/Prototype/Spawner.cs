using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyStats baseStats;
    [SerializeField] private EnemyUnit enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnTime;


    private EnemyStats fireEnemy1;
    private EnemyStats fireEnemy2;
    private EnemyStats fireEnemy3;

    void Start()
    {
        fireEnemy1 = baseStats.Clone();
        fireEnemy1.name = "Fogo 1";
        fireEnemy1.health = 1;
        fireEnemy1.speed = 2;
        fireEnemy1.scoreGiven = 10;
        fireEnemy1.enemyColor = Color.yellow;

        fireEnemy2 = baseStats.Clone();
        fireEnemy2.name = "Fogo 2";
        fireEnemy2.health = 2;
        fireEnemy2.speed = 4;
        fireEnemy2.scoreGiven = 15;
        fireEnemy2.enemyColor = Color.red;

        fireEnemy3 = baseStats.Clone();
        fireEnemy3.name = "Fogo 3";
        fireEnemy3.health = 3;
        fireEnemy3.speed = 6;
        fireEnemy3.scoreGiven = 30;
        fireEnemy3.enemyColor = Color.rebeccaPurple;

        StartCoroutine(Spawn());
    }


    void CreateEnemy(int spawnIndex)
    {
        EnemyUnit enemy = Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        int indexEnemy = Random.Range(1, 4);
        if (indexEnemy == 1)
        {
            enemy.Setup(fireEnemy1);
        }
        else if (indexEnemy == 2)
        {
            enemy.Setup(fireEnemy2);
        }
        else if (indexEnemy == 3)
        {
            enemy.Setup(fireEnemy3);
        }
    }

    IEnumerator Spawn()
    {
        //Spawn Point 0
        yield return new WaitForSeconds(spawnTime);
        CreateEnemy(0);

        //Spawn Point 1
        yield return new WaitForSeconds(spawnTime);
        CreateEnemy(1);

        //Spawn Point 2
        yield return new WaitForSeconds(spawnTime);
        CreateEnemy(2);

        //Spawn Point 3
        yield return new WaitForSeconds(spawnTime);
        CreateEnemy(3);

        //Reestart Coroutine
        StartCoroutine(Spawn());
    }
}
