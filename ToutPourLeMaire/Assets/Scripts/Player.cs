using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    private Vector2 movement;
    private float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movePlayer = new Vector3(movement.x,0, movement.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movePlayer);
    }

    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
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
