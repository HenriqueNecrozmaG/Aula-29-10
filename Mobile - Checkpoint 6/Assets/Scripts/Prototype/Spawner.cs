using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] EnemyStats baseStats;
    [SerializeField] EnemyUnit enemyPrefab;

    EnemyStats fireEnemy1;
    EnemyStats fireEnemy2;
    EnemyStats fireEnemy3;

    void Start()
    {
        fireEnemy1 = baseStats.Clone();
        fireEnemy1.name = "Fogo 1";
        fireEnemy1.health = 1;
        fireEnemy1.speed = 2;
        fireEnemy1.scoreGiven = 10;
        fireEnemy1.enemyColor = Color.yellow;
        EnemyUnit enemy1 = Instantiate(enemyPrefab, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
        enemy1.Setup(fireEnemy1);

        fireEnemy2 = baseStats.Clone();
        fireEnemy2.name = "Fogo 2";
        fireEnemy2.health = 2;
        fireEnemy2.speed = 4;
        fireEnemy2.scoreGiven = 15;
        fireEnemy2.enemyColor = Color.red;
        EnemyUnit enemy2 = Instantiate(enemyPrefab, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
        enemy2.Setup(fireEnemy2);

        fireEnemy3 = baseStats.Clone();
        fireEnemy3.name = "Fogo 3";
        fireEnemy3.health = 3;
        fireEnemy3.speed = 6;
        fireEnemy3.scoreGiven = 30;
        fireEnemy3.enemyColor = Color.rebeccaPurple;
        EnemyUnit enemy3 = Instantiate(enemyPrefab, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
        enemy3.Setup(fireEnemy3);
    }
}
