using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController = null;
    private Vector2 moveInput = new Vector2();
    [SerializeField]private float moveSpeed = 5;
    [SerializeField] private Transform cam;
    [SerializeField] private float camFollowDistance = 5;
    private Vector2 cameraPoint = new Vector2();

    [SerializeField] private GameObject survivorPrefab;
    public List<FollowerBehaviour> followers;

    private Gun gun;
    
    private void Awake()
    {
        if (!gameObject.TryGetComponent(out characterController))
        {
            Debug.Log("Character Controller not assigned");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 delta;

        delta = (moveInput.normalized) * (moveSpeed * Time.fixedDeltaTime);
        characterController.Move(delta);

        if (Vector2.Distance(transform.position,cameraPoint) > camFollowDistance)
        {
            cameraPoint += delta;
        }

        cam.position = Vector3.Slerp(cam.position,new Vector3(cameraPoint.x,
            Mathf.RoundToInt(cam.position.y * 100) / 100,cam.position.z),moveSpeed * Time.fixedDeltaTime);
        
    }

    public void AddFollower(Transform spawnPos)
    {
        // instantiates a new survivor
        GameObject survivor = Instantiate(survivorPrefab, spawnPos.position, Quaternion.identity);
        FollowerBehaviour newFollower = survivor.GetComponent<FollowerBehaviour>();

        // Runs the SetTarget function for the survivor
        int index = followers.Count - 1;
        followers.Add(newFollower);
        newFollower.SetTarget(this, index);
    }

    public void RemoveFollower()
    {
        if (followers.Count <= 0)
            return;
        
        // Sets the second survivor to the new leader
        if (followers.Count > 1)
            followers[1].SetTarget(this, -1);
        
        // Destroys the first survivor
        Destroy(followers[0].gameObject);
        followers.Remove(followers[0]);
    }

    public bool AddAmmo(int _ammo)
    {
        if (gun.ammo == gun.clipSize)
        {
            return false;
        }
        
        if (_ammo > gun.clipSize)
        {
            _ammo = gun.clipSize;
        }
        else
        {
            gun.ammo = _ammo;
        }

        return true;
    }

    public void SetGun(Gun _gun) => gun = _gun;
}
