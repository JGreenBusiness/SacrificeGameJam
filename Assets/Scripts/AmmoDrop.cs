using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AmmoDrop : MonoBehaviour
    {
        [SerializeField] int ammoAmount = 5;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                if (player.AddAmmo(ammoAmount))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}