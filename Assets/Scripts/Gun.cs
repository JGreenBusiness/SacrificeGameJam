using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Gun : MonoBehaviour
    {
        
        [SerializeField] private Transform owner;
        private Player player;
        [SerializeField] private Bullet bullet = null;
        private bool shootInput = false;
        [SerializeField] private float gunDistance = 1f;
        [SerializeField] private float bulletDistance = .3f;
        [SerializeField] private float fireRate = .3f;
        private float fireTimer = 0f;
        private bool fired = false;
        
        public int clipSize = 10;
        public int ammo;

        private void Awake()
        {
        }

        private void Start()
        {
            if (owner.TryGetComponent(out player))
            {
                player.SetGun(this);
            }
            fireTimer = fireRate;
            ammo = clipSize;
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
            
            if(!fired && shootInput && ammo > 0)
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
            ammo--;
        }
        
    }
}