using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA.pooling
{
    [System.Serializable]
    public class EnemyPool
    {
        public string tag;
        public GameObject enemyPrefab;
        public int amount;
    }
}
