using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnOffset = 1f;

    public Transform player;

    public GameObject enemy;

    public List<GameObject> enemyList = new List<GameObject>();

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            SpawnEnemy();
    }

    void SpawnEnemy()
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

    public void DestroyAllEnemy()
    {
        foreach(GameObject _enemy in enemyList)
        {
            Destroy(_enemy);
        }
    }
}
