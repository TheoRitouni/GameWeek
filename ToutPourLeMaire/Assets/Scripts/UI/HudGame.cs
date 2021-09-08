using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class HudGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI flyerRedText;
    [SerializeField] private TextMeshProUGUI flyerBlueText;

    [Space]
    [SerializeField] private float timerGame = 60f;


    void Update()
    {
        if (timerGame > 0)
            timerGame -= Time.deltaTime;

        timerText.text = ((int)timerGame).ToString();
    }

    public void SetTextFlyerRed(int flyernbr)
    {
        flyerRedText.text = (flyernbr).ToString();
    }

    public void SetTextFlyerBlue(int flyernbr)
    {
        flyerBlueText.text = (flyernbr).ToString();
    }

    
}
