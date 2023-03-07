using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class AIManagerSingleton : MonoBehaviour
    {
        public List<AIBase> ai;
        public Transform playerTrans;
        public List<SurvivorSpawner> survivorSpawners;
        public List<ZombieSpawner> zombieSpawners;
        
        public int zombieLimit;
        public int zombieCount;
        public int survivorLimit;
        public int survivorCount;
        
        public static AIManagerSingleton instance;

        private void Awake()
        {
            if (instance != null)
                return;

            instance = this;
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < ai.Count; i++)
                    ai[i].Move(Time.fixedDeltaTime);
            
            if(survivorCount < survivorLimit)
                for (int i = 0; i < survivorSpawners.Count; i++)
                    survivorSpawners[i].UpdateSpawner(Time.fixedDeltaTime);

            if(zombieCount < zombieLimit)
                for (int i = 0; i < 2; i++)
                    zombieSpawners[i].UpdateSpawner(Time.fixedDeltaTime);
        }
    }
}