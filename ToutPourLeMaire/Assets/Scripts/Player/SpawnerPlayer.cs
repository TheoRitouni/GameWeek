using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerPlayer : MonoBehaviour
{
    private int countPlayer = 0;
    [SerializeField]private Transform spawn1;
    [SerializeField]private Transform spawn2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    { 
        countPlayer++;

        if (countPlayer == 1)
            playerInput.gameObject.transform.position = spawn1.position;

        if (countPlayer == 2)
            playerInput.gameObject.transform.position = spawn2.position;

    }

    private void OnPlayerLeft()
    {
        countPlayer--;
    }
}
