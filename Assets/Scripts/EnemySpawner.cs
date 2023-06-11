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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            SpawnEnemy();

        if(Input.GetKeyDown(KeyCode.R))
            SpawnItem();
    }

    void SpawnEnemy()
    {
        // Vector3 playerPosition = player.position;

        // Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

        // Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

        // GameObject _enemy = Instantiate(enemy,offScreenPosition,Quaternion.identity); //spawn enemy
        
        GameObject _enemy = Instantiate(enemy,RandomSpawnPosition(),Quaternion.identity); //spawn enemy with random position function
        
        enemyList.Add(_enemy);
    }

    void SpawnItem()
    {
        // Vector3 playerPosition = player.position;

        // Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

        // Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

        

        GameObject randomItem = items[Random.Range(0,items.Count)];

        // GameObject _item = Instantiate(randomItem,offScreenPosition,Quaternion.identity); //spawn enemy

        GameObject _item = Instantiate(randomItem,RandomSpawnPosition(),Quaternion.identity); //spawn enemy with random position function
    }

    Vector3 RandomSpawnPosition()
    {
        Vector3 playerPosition = player.position;

        Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

        Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

        return offScreenPosition;
    }
    

    public void DestroyAllEnemy()
    {
        foreach(GameObject _enemy in enemyList)
        {
            Destroy(_enemy);
        }
    }
}
