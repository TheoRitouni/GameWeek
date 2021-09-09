using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private TextMeshPro flyerBlueText;
    [SerializeField] private TextMeshPro flyerRedText;

    [SerializeField] private GameObject flyerBulletBlue;
    [SerializeField] private GameObject flyerBulletRed;


    [SerializeField] private GameObject flyerSpawner;

    public Action onShoot;
    public Action onShootFailed;

    [Space]
    [Header("Flyer")]
    [SerializeField] private int startFlyer = 15;
    [SerializeField] private int maxFlyer = 20;
    private int flyerRemaining;

    private GameObject hudGameObject;
    private HudGame hudgame;

    // Start is called before the first frame update
    void Start()
    {
        flyerRemaining = startFlyer;
        hudGameObject = GameObject.FindGameObjectWithTag("HUD");
        hudgame = hudGameObject.GetComponent<HudGame>();
        SetFlyerHUD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnShoot()
    {
        if (flyerRemaining >= 1)
        {
            if (tag == "PlayerB")
                Instantiate(flyerBulletBlue, flyerSpawner.transform.position, transform.rotation);

            if (tag == "PlayerR")
                Instantiate(flyerBulletRed, flyerSpawner.transform.position, transform.rotation);

            onShoot?.Invoke();

            flyerRemaining--;

            SetFlyerHUD();

        }
        else if(flyerRemaining == 0)
        {
            onShootFailed?.Invoke();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PileFlyers"))
        {
            flyerRemaining += other.GetComponent<ReloadFlyers>().reloadFlyer;

            //Play Flyer Pile Taken Visual
            other.GetComponent<FlyerVisual>().OnFlyerPileTake();

            if (flyerRemaining > maxFlyer)
                flyerRemaining = maxFlyer;

            SetFlyerHUD();
        }
    }

    private void SetFlyerHUD()
    {
        if (tag == "PlayerB")
            flyerBlueText.text = (flyerRemaining).ToString();

        if (tag == "PlayerR")
            flyerRedText.text = (flyerRemaining).ToString();

    }
}
