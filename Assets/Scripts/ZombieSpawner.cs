using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> zombies;
        [SerializeField] private float spawnTime = 1;
        [SerializeField] private float timer;

        private int zombiePick;
        
        private void Update()
        {
            zombiePick++;
            
            if (zombiePick >= zombies.Count)
                zombiePick = 0;
        }
        
        public void UpdateSpawner(float dt)
        {
            if (timer < spawnTime)
            {
                timer += dt;
                return;
            }

            AIManagerSingleton.instance.zombieCount++;
            
            Instantiate(zombies[zombiePick], transform.position, Quaternion.identity);

            timer = 0;
        }
    }
}