using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedbacks : MonoBehaviour
{
    [SerializeField] PlayerShoot playerShoot;

    [Header("Data")]
    [SerializeField] HitstopData hitstopData;
    [SerializeField] ShakeData shakeData;

    private void Start()
    {
        playerShoot.onShoot += OnShoot;
    }

    void OnShoot()
    {
        ShakeManager.getInstance().Shake(shakeData);
    }
}
