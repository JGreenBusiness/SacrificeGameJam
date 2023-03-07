using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class SurvivorSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> survivors;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnTime = 1;
        [SerializeField] private float timer;

        public bool canSpawn;

        private int survivorPick;
        
        private void Update()
        {
            survivorPick++;

            if (survivorPick >= survivors.Count)
                survivorPick = 0;
        }

        public void UpdateSpawner(float dt)
        {
            if (!canSpawn)
                return;
            
            if (timer < spawnTime)
            {
                timer += dt;
                return;
            }

            AIManagerSingleton.instance.survivorCount++;
            
            AIManagerSingleton.instance.playerTrans.GetComponent<Player>().AddFollower(spawnPoint);

            timer = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                canSpawn = true;
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                canSpawn = false;
        }
    }
}