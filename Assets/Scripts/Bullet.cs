using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        public Vector2 direction;
        [SerializeField]private float timeToDecay = 2;
        [SerializeField]private float bulletSpeed = 2;


        private void Awake()
        {
        }


        private void Update()
        {
            
            if (timeToDecay >= 0)
            {
                timeToDecay -= Time.deltaTime;
                transform.position += new Vector3(direction.x,direction.y,0) * (Time.deltaTime * bulletSpeed);
            }
            else
            {
                if (gameObject!= null)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hit");
            if (other.TryGetComponent(out ZombieBehaviour _enemy))
            {
                Debug.Log("Enemy Hit");
                Destroy(_enemy.gameObject);
                Destroy(gameObject);
            }
        }
    }
}