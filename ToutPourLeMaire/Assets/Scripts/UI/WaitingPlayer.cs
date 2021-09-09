using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitingPlayer : MonoBehaviour
{
    [HideInInspector] public bool waitPlayers = true;
    [HideInInspector] public int nbrPlayer = 0;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI waitingText;


    [SerializeField] private float timerBeginGame = 5f;

    void Start()
    {
        waitPlayers = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (nbrPlayer == 2)
        {
            timerBeginGame -= Time.deltaTime;
            waitingText.text = "";
        }

        if (timerBeginGame < 0)
            waitPlayers = false;

        if (waitPlayers)
            timerText.text = ((int)timerBeginGame).ToString();
            
    }
}
