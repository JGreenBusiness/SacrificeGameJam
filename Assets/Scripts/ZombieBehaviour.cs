using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ZombieBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float stopThreshold;

        [SerializeField] private Vector2 attackBounds;
        
        public void SetTarget(Transform _target)
        {
            target = _target;
        }

        public void Move(float dt)
        {
            Vector2 newPos = transform.position;
            
            Vector2 direction = (Vector2)target.position - newPos;
            direction.Normalize();

            // Checks the distance from the target and stops if within this distance
            float distance = Vector2.Distance(transform.position, target.position);
            // Applies movement to the zombie
            newPos += direction * (moveSpeed * (distance <= stopThreshold ? 0 : dt));
            
            transform.position = newPos;
        }

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