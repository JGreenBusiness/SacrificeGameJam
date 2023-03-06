using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ZombieBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float moveSpeed;

        public void SetTarget(Transform _target)
        {
            target = _target;
        }

        public void Move()
        {
            Vector2 newPos = transform.position;
            
            Vector2 direction = (Vector2)target.position - newPos;
            direction.Normalize();

            newPos += direction * moveSpeed * Time.deltaTime;
            
            transform.position = newPos;
        }

        private void Update()
        {
            Move();
        }
    }
}