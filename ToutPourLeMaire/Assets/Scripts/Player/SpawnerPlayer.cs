using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerPlayer : MonoBehaviour
{
    private int countPlayer = 0;
    [SerializeField]private Transform spawn1;
    [SerializeField]private Transform spawn2;

    [Space]
    [SerializeField] private GameObject playerRedPrefab;

    private PlayerInputManager playerIM;

    [Space]
    [SerializeField] private WaitingPlayer infoWait;



    // Start is called before the first frame update
    void Start()
    {
        playerIM = gameObject.GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    { 
        countPlayer++;
        infoWait.nbrPlayer++;

        if (countPlayer == 1)
        {
            playerInput.gameObject.transform.position = spawn1.position;
            playerIM.playerPrefab = playerRedPrefab;
        }

        if (countPlayer == 2)
            playerInput.gameObject.transform.position = spawn2.position;

    }

    private void OnPlayerLeft()
    {
        countPlayer--;
        infoWait.nbrPlayer--;

    }
}
