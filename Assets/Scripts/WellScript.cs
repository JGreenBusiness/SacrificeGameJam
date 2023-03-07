using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class WellScript : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private GameObject ammoPrefab;

        private bool canSacri;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E) && canSacri)
            {
                Sacrifice();
                AIManagerSingleton.instance.survivorCount--;
            }
        }

        private void Sacrifice()
        {
            player.RemoveFollower();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                canSacri = true;
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                canSacri = false;
        }
    }
}