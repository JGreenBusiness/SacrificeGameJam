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

    public List<FollowerBehaviour> followers;

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

        cam.position = Vector3.Slerp(cam.position,new Vector3(cameraPoint.x,cameraPoint.y,cam.position.z),moveSpeed * Time.fixedDeltaTime);
    }
}
