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

    bool victoryMenu = false;

    [SerializeField] private TextMeshProUGUI victoryText;


    private void Start()
    {
        rateRedText.text = (rateRed).ToString() + "%";
        rateBlueText.text = (rateBlue).ToString() + "%";

        imageRedBar.fillAmount = rateRed / 100f;
    }


    void Update()
    {
        if (timerGame > 0)
            timerGame -= Time.deltaTime;
        if (timerGame <= 0 && !victoryMenu)
        {
            victoryText.enabled = true;

            if (rateRed > rateBlue)
                victoryText.text = "Red Win";
            else if (rateRed < rateBlue) 
                victoryText.text = "Blue Win";
            else
                victoryText.text = "Egality";

            Time.timeScale = 0;
            victoryMenu = true;
            SceneManager.LoadScene("VictoryMenu", LoadSceneMode.Additive);
        }

        timerText.text = ((int)timerGame).ToString();

        if (countBluePnj > 0 || countRedPnj > 0)
            ResultOfRate();
    }

    public void SetTextFlyerRed(int flyernbr)
    {
        flyerRedText.text = (flyernbr).ToString();
    }

    public void SetTextFlyerBlue(int flyernbr)
    {
        flyerBlueText.text = (flyernbr).ToString();
    }

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
