using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedbacks : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerShoot playerShoot;

    [Header("Data")]
    [SerializeField] HitstopData hitstopData;
    [SerializeField] ShakeData shakeData;

    private void Start()
    {
        playerShoot.onShoot += OnShoot;
        playerMovement.onRunning += OnRunning;
    }

    void OnShoot()
    {
        playerAnimator.SetTrigger("Shoot");
        ShakeManager.getInstance().Shake(shakeData);
    }

    private void OnRunning(bool isRunnning)
    {
        playerAnimator.SetBool("isRunning", isRunnning);
    }
}
