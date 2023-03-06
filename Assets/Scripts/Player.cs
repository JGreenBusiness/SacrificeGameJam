using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController = null;
    private Vector2 moveInput = new Vector2();
    [SerializeField]private float moveSpeed = 5;
    [SerializeField] private Transform cam;

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
        delta = (moveInput) * (moveSpeed * Time.fixedDeltaTime);
        characterController.Move(delta);
    }
}
