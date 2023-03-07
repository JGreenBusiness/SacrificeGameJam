using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AmmoPackSpawner : MonoBehaviour
    {
        [SerializeField] private AmmoDrop ammoPackPrefab; 
        private AmmoDrop droppedAmmo;
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private float spawnTimer = 0f;

        private void Update()
        {
            if (spawnTimer >= 0 && droppedAmmo == null)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                droppedAmmo = Instantiate(ammoPackPrefab, transform);
                spawnTimer = spawnRate;
            }
        }
    }
}