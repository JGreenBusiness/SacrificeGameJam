using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        public Vector2 direction;
        private float timeToDecay = 2;
        
        [SerializeField]private float bulletSpeed = 2;

        
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
    }
}