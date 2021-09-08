using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 20f;

    private Rigidbody rigid;
    private Vector3 frameMovement;

    private bool isRunning;

    public Action<bool> onRunning;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMove(InputValue value)   
    {
        movement = value.Get<Vector2>();

        if (movement.sqrMagnitude > 0.1)
        {
            float angle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, angle, 0)), Time.deltaTime * rotationSpeed);
        }

        if (movement.sqrMagnitude > 0.01)
        {
            rigid.velocity = transform.forward * moveSpeed;
            
            if (!isRunning)
            {
                isRunning = true;
                onRunning?.Invoke(isRunning);
            }
        }
        else
        {
            rigid.velocity = Vector3.zero;

            if (isRunning)
            {
                isRunning = false;
                onRunning?.Invoke(isRunning);
            }
        }
    }

    private void OnMoveUp()
    {
        Debug.Log("up");
    }
    private void OnMoveDown()
    {
        Debug.Log("down");
    }
}
