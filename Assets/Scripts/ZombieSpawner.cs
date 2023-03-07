using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject zombiePrefab;
        [SerializeField] private float spawnTime = 1;
        [SerializeField] private float timer;

        public void UpdateSpawner(float dt)
        {
            if (timer < spawnTime)
            {
                timer += dt * Random.value;
            }
            
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);

            timer = 0;
        }
    }
}