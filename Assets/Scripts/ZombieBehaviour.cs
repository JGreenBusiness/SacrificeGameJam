using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ZombieBehaviour : AIBase
    {
        [SerializeField] private Vector2 attackBounds;

        private void Update()
        {
            Move(Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            Color prevCol = Gizmos.color;
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, (Vector3)attackBounds + Vector3.forward);
        }
    }
}