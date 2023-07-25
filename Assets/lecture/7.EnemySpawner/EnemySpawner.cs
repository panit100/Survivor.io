using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TA.pooling;

namespace TA
{
    public class EnemySpawner : MonoBehaviour
    {
        public float spawnOffset = 1f;
        public Transform player;

        public float gameTime;
        [SerializeField] private int enemySetCount;
        public List<EnemySet> enemySet = new List<EnemySet>();
        private bool isGameTimeActive = true;

        [HideInInspector] public List<GameObject> enemyContainer = new List<GameObject>();

        public List<EnemyPool> enemyPoolList;
        public Dictionary<string,Queue<EnemyHealth>> enemyPoolDictionary;
        
        void Awake()
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        void Start()
        {
            InitializePool();

            InvokeRepeating("SpawnSequence",1f ,1f);
    
            SetTimeOfEnemySet();
        }

        [SerializeField] private List<float> enemyWaveTimeList;
        private void SetTimeOfEnemySet()
        {
            for(int i = 0; i < enemySet.Count; i++)
            {
                enemyWaveTimeList.Add(enemySet[i].timeWave);
            }
            
            CheckWaveTimeList();
            ApplyTimeOfEnemySet();
        }
        private void CheckWaveTimeList()
        {
            for(int i = 0; i < enemyWaveTimeList.Count; i++)
            {
                if(i == 0)
                {
                    continue;
                }
                else if(i > 0 && enemyWaveTimeList[i - 1] >= enemyWaveTimeList[i])
                {
                    enemyWaveTimeList[i] = enemyWaveTimeList[i-1] + 60f;
                }
            }
        }
        private void ApplyTimeOfEnemySet()
        {
            int count = 0;
            foreach(EnemySet enemySetTmep in enemySet)
            {
                enemySetTmep.timeWave = enemyWaveTimeList[count];
                count++;
            }
        }


        void InitializePool()
        {
            enemyPoolDictionary = new Dictionary<string, Queue<EnemyHealth>>();
        
            foreach(EnemyPool pool in enemyPoolList)
            {
                Queue<EnemyHealth> enemyPool = new Queue<EnemyHealth>();

                for(int i = 0; i < pool.amount; i++)
                {
                    GameObject enemy = Instantiate(pool.enemyPrefab,transform);
                    EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                    enemyHealth.enemySpawner = this;
                    enemyHealth.gameObject.SetActive(false);
                    enemyPool.Enqueue(enemyHealth);
                }

                enemyPoolDictionary.Add(pool.tag,enemyPool);
            }
        }

        void SpawnEnemyFromPool(string tag)
        {
            EnemyHealth enemyToSpawn = enemyPoolDictionary[tag].Dequeue();

            enemyToSpawn.transform.position = RandomSpawnPosition();
            enemyToSpawn.gameObject.SetActive(true);
            enemyToSpawn.currentHealth = enemyToSpawn.health;

            enemyPoolDictionary[tag].Enqueue(enemyToSpawn);

            enemyContainer.Add(enemyToSpawn.gameObject);
        }

        Vector3 RandomSpawnPosition()
        {
            Vector3 playerPosition = player.position;

            Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

            Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

            return offScreenPosition;
        }

        private void SpawnSequence()
        {
            CountTime();
            CheckSpawnWave();
            CheckSpawnValue();
        }
        private void CountTime()
        {
            if(isGameTimeActive)
            {
                gameTime += 1;
            }
        }
        private void CheckSpawnWave()
        {
            if(gameTime == enemyWaveTimeList[0])
            {
                enemySetCount = 0;
            }
            else if(enemySetCount + 1 == enemySet.Count)
            {
                return;
            }
            else if(gameTime == enemyWaveTimeList[enemySetCount + 1])
            {
                enemySetCount++;
            }
        }
        private void CheckSpawnValue()
        {
            foreach(EnemySetDetail enemySetDetail in enemySet[enemySetCount].enemySetDetail)
            {
                if(gameTime % enemySetDetail.enemySpawnEverySecond == 0)
                {
                    for (int i = 0; i < enemySetDetail.enemySpawnTotal ; i++)
                    {
                        SpawnEnemyFromPool(enemySetDetail.enemyTag);
                    }
                }
            }
        }

        public void StopGameTime()
        {
            isGameTimeActive = false;
        }
        public void ContinueGameTime()
        {
            isGameTimeActive = true;
        }

        public void DestroyAllEnemy()
        {
            foreach(GameObject _enemy in enemyContainer)
            {
                _enemy.SetActive(false);
            }
        }

        private void OnDrawGizmos() 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(player.position, spawnOffset);
        }
    }
}

