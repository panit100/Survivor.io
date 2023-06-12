using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnOffset = 1f;

    public Transform player;

    public List<GameObject> enemyList = new List<GameObject>();
    public float gameTime;
    public List<EnemySet> enemySet = new List<EnemySet>();
    int enemySetCount;

    void Start()
    {
        InvokeRepeating("SpawnSequence",1f ,1f);
    }

    void SpawnSequence()
    {
        CountTime();
        CheckSpawnTime();
    }

    void SpawnEnemy(GameObject enemy)
    {
        // Camera mainCam = Camera.main;

        // float cameraHight = 2f * mainCam.orthographicSize;
        // float cameraWidth = cameraHight * mainCam.aspect;
        // Vector3 randomPosition = new Vector3(Random.Range(-cameraWidth/2,cameraWidth/2),Random.Range(-cameraHight/2,cameraHight/2),0);

        // Vector3 offScreenPosition = mainCam.transform.position + (randomPosition.normalized * spawnOffset);

        // print($"x : {offScreenPosition}, y : {offScreenPosition}");
        // Instantiate(enemy,offScreenPosition,Quaternion.identity);

        Vector3 playerPosition = player.position;

        Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

        Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

        print($"x : {offScreenPosition}, y : {offScreenPosition}");
        GameObject _enemy = Instantiate(enemy,offScreenPosition,Quaternion.identity); //spawn enemy
        enemyList.Add(_enemy);
    }

    void CountTime()
    {
        gameTime += 1;
    }

    void CheckSpawnTime()
    {
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
                CheckSetCountIncrease();
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
                for (int i = 0; i < enemySet[enemySetCount].enemySetDetail[setCountTemp].enemySpawnCount; i++)
                {
                    SpawnEnemy(enemySet[enemySetCount].enemySetDetail[setCountTemp].enemyPrefab);
                }
            }
            setCountTemp++;
        }
    }
    void CheckSetCountIncrease()
    {
        if(gameTime + 1 == enemySet[enemySetCount + 1].timeWave)
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