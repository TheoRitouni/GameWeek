using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedbacks : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    [Header("Scripts")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerShoot playerShoot;

    [Header("Data")]
    [SerializeField] HitstopData hitstopData;
    [SerializeField] ShakeData shakeData;

    [Header("Audio")]
    [SerializeField] AudioSource audioRun;

    private void Start()
    {
        playerShoot.onShoot += OnShoot;
        playerMovement.onStartRunning += OnStartRunning;
        playerMovement.onStopRunning += OnStopRunning;
    }

    void OnShoot()
    {
        playerAnimator.SetTrigger("Shoot");
        ShakeManager.getInstance().Shake(shakeData);
    }

    private void OnStartRunning()
    {
        playerAnimator.SetBool("isRunning", true);
        audioRun.Play();
    }

    private void OnStopRunning()
    {
        playerAnimator.SetBool("isRunning", false);
        audioRun.Stop();
    }

}
