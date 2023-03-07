using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Gun : MonoBehaviour
    {
        
        [SerializeField] private Transform owner;
        [SerializeField] private Bullet bullet = null;
        private bool shootInput = false;
        [SerializeField] private float gunDistance = 1f;
        [SerializeField] private float bulletDistance = .3f;
        [SerializeField] private float fireRate = .3f;
        private float fireTimer = 0f;
        private bool fired = false;
        private void Awake()
        {
        }

        private void Start()
        {
            fireTimer = fireRate;
        }

        private void Update()
        {
            if (fireTimer >= 0 && fired)
            {
                fireTimer -= Time.deltaTime;
            }
            else
            {
                shootInput = Input.GetButton("Fire1");
                fired = false;
                fireTimer = fireRate;
            }
        }

        private void FixedUpdate()
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)((worldMousePos - transform.position)).normalized;
            
            transform.LookAt(new Vector3(worldMousePos.x,worldMousePos.y,transform.position.z));
            
            if(!fired && shootInput)
            {
                Shoot(direction);
            }

            if (owner != null)
            {
                transform.position = owner.position + transform.right*gunDistance;
            }
        }

        public void Shoot(Vector2 _dir)
        {
            
            bullet.direction = transform.forward;
            Vector3 bulletPoint = transform.position + (transform.right*bulletDistance);
            Instantiate(bullet,new Vector3(bulletPoint.x,bulletPoint.y,0),transform.rotation);
            fired = true;
        }
        
    }
}