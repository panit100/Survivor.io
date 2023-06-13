using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public float spawnOffset = 1f;

    public Transform player;

    public List<GameObject> itemList = new List<GameObject>();    

    void Start()
    {
        InvokeRepeating("SpawnItem",1f ,10f);
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.R))
            SpawnItem();
    }

    void SpawnItem()
    {
        GameObject randomItem = itemList[Random.Range(0,itemList.Count)];

        GameObject _item = Instantiate(randomItem,RandomSpawnPosition(),Quaternion.identity); //spawn enemy with random position function
    }

    Vector3 RandomSpawnPosition()
    {
        Vector3 playerPosition = player.position;

        Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

        Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

        return offScreenPosition;
    }
}
