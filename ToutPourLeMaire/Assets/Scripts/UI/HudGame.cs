using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HudGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI flyerRedText;
    [SerializeField] private TextMeshProUGUI flyerBlueText;

    [Space]
    [SerializeField] private float timerGame = 60f;

    [Space]
    [SerializeField] private TextMeshProUGUI rateRedText;
    [SerializeField] private TextMeshProUGUI rateBlueText;

    [SerializeField] private Image imageRedBar;

    private int rateRed = 50;
    private int rateBlue = 50;

    [HideInInspector] public int countBluePnj = 0;
    [HideInInspector] public int countRedPnj = 0;

    [HideInInspector]public bool victoryMenu = false;

    [SerializeField] private TextMeshProUGUI victoryText;

    [Space]
    [SerializeField] private WaitingPlayer infoWait;
    [HideInInspector] public bool waitPlayer;
    [SerializeField] private AudioSource audioSource;
    private bool musicTimer = false;


    private void Start()
    {
        waitPlayer = infoWait.waitPlayers;
        rateRedText.text = (rateRed).ToString() + "%";
        rateBlueText.text = (rateBlue).ToString() + "%";

        imageRedBar.fillAmount = rateRed / 100f;
    }


    void Update()
    {
        if (!infoWait.waitPlayers)
        {
            if(timerGame < 10 && timerGame > 0 && !musicTimer)
            {
                musicTimer = true;
                audioSource.Play();
            }
                
            if (timerGame > 0)
                timerGame -= Time.deltaTime;
            if (timerGame <= 0 && !victoryMenu)
            {
                musicTimer = false;
                victoryText.enabled = true;

                if (rateRed > rateBlue)
                    victoryText.text = "Red Won the elections";
                else if (rateRed < rateBlue)
                    victoryText.text = "Blue Won the elections";
                else
                    victoryText.text = "Egality, you have to do one more!";

                Time.timeScale = 0;
                victoryMenu = true;
                SceneManager.LoadScene("VictoryMenu", LoadSceneMode.Additive);
            }

            timerText.text = ((int)timerGame).ToString();

            if (countBluePnj > 0 || countRedPnj > 0)
                ResultOfRate();
        }

        waitPlayer = infoWait.waitPlayers;

    }

    //public void SetTextFlyerRed(int flyernbr)
    //{
    //    flyerRedText.text = (flyernbr).ToString();
    //}

    //public void SetTextFlyerBlue(int flyernbr)
    //{
    //    flyerBlueText.text = (flyernbr).ToString();
    //}

    private void ResultOfRate()
    {
        int pollRemaining = countBluePnj + countRedPnj;

        rateRed = countRedPnj * 100 / pollRemaining;
        rateBlue = countBluePnj * 100 / pollRemaining;

        rateRedText.text = (rateRed).ToString() + "%";
        rateBlueText.text = (rateBlue).ToString() + "%";

        imageRedBar.fillAmount = rateRed / 100f;
    }


}
