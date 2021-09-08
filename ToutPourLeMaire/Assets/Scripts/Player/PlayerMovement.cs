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

    public Action onStartRunning;
    public Action onStopRunning;

    [SerializeField] private float forceBump = 200f;

    private PlayerInput playerInput;
    //[SerializeField] private InputActionAsset inputaction;

    private bool isBump = false;
    [SerializeField] private float timerBump = 0.2f;
    private float saveTimerBump = 0.0f;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        saveTimerBump = timerBump;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBump)
        {
            timerBump -= Time.deltaTime;
            
            if(timerBump <= 0)
            {
                timerBump = saveTimerBump;
                isBump = false;
            }
        }

    }


    private void OnMove(InputValue value)   
    {
        movement = value.Get<Vector2>();

        if (movement.sqrMagnitude > 0.1)
        {
            float angle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, angle, 0)), Time.deltaTime * rotationSpeed);
        }

        if(!isBump)
            MovementJoystick();
        
    }

    private void MovementJoystick()
    {
        if (movement.sqrMagnitude > 0.01)
        {
            rigid.velocity = transform.forward * moveSpeed;

            if (!isRunning)
            {
                isRunning = true;
                onStartRunning?.Invoke();
            }
        }
        else
        {
            rigid.velocity = Vector3.zero;

            if (isRunning)
            {
                isRunning = false;
                onStopRunning?.Invoke();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("PlayerB"))
            BumpFonction(collision);

        if (collision.collider.CompareTag("PlayerR"))
            BumpFonction(collision);
    }

    private void BumpFonction(Collision collision)
    {
        isBump = true;
        rigid.velocity = Vector3.zero;
        rigid.AddForce(collision.collider.transform.forward * forceBump, ForceMode.Impulse);
        collision.collider.GetComponent<Rigidbody>().AddForce
        (transform.forward * forceBump, ForceMode.Impulse);
    }


}
