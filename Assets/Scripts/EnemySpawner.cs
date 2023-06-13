using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnOffset = 1f;

    public Transform player;

    public GameObject enemy;

    public List<GameObject> items = new List<GameObject>();    

    public List<GameObject> enemyList = new List<GameObject>();
    public float gameTime;
    public List<EnemySet> enemySet = new List<EnemySet>();
    int enemySetCount;

    void Start()
    {
        InvokeRepeating("SpawnSequence",1f ,1f);
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E))
            SpawnEnemy();

        if(Input.GetKeyDown(KeyCode.R))
            SpawnItem();
    }

    void SpawnSequence()
    {
        CountTime();
        CheckSpawnTime();
    }

    void SpawnEnemy(GameObject enemy)
    {
        GameObject _enemy = Instantiate(enemy,RandomSpawnPosition(),Quaternion.identity); //spawn enemy with random position function
        
        enemyList.Add(_enemy);
    }

    void SpawnItem()
    {
        GameObject randomItem = items[Random.Range(0,items.Count)];

        GameObject _item = Instantiate(randomItem,RandomSpawnPosition(),Quaternion.identity); //spawn enemy with random position function
    }

    Vector3 RandomSpawnPosition()
    {
        Vector3 playerPosition = player.position;

        Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

        Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

        return offScreenPosition;
    }
    

    void CountTime()
    {
        gameTime += 1;
    }

    void CheckSpawnTime()
    {
        CheckSetCountIncrease();
        if(enemySet.Count - 1 == enemySetCount)
        {
            if(gameTime >= enemySet[enemySetCount].timeWave)
            {
                CheckSpawnValue();
            }
        }
        else
        {
            if(gameTime >= enemySet[enemySetCount].timeWave 
            && gameTime < enemySet[enemySetCount + 1].timeWave)
            {
                CheckSpawnValue();
            }
        }
    }
    void CheckSpawnValue()
    {
        int setCountTemp = 0;

        foreach(EnemySet enemySetTemp in enemySet)
        {
            if(gameTime % enemySet[enemySetCount].enemySetDetail[setCountTemp].enemySpawnTime == 0)
            {
                for (int i = 0; i < enemySet[enemySetCount].enemySetDetail[setCountTemp].enemySpawnCount ; i++)
                {
                    SpawnEnemy(enemySet[enemySetCount].enemySetDetail[setCountTemp].enemyPrefab);
                }
            }
            setCountTemp++;
        }
    }
    void CheckSetCountIncrease()
    {
        if(enemySet.Count - 1 == enemySetCount) { return; }
        if(gameTime == enemySet[enemySetCount + 1].timeWave)
        {
            enemySetCount++;
        }
    }

    public void DestroyAllEnemy()
    {
        foreach(GameObject _enemy in enemyList)
        {
            Destroy(_enemy);
        }
    }
}

[System.Serializable]
public class EnemySet
{
    public float timeWave;
    public List<EnemySetDetail> enemySetDetail;
}
[System.Serializable]
public class EnemySetDetail
{
    public GameObject enemyPrefab;
    public int enemySpawnCount;
    public float enemySpawnTime;
}