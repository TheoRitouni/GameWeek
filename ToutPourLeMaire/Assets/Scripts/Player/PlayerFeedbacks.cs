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

    [Header("Sounds")]
    [SerializeField] AudioClip[] audioClips;

    [Header("Audio")]
    [SerializeField] AudioSource audioRun;
    [SerializeField] AudioSource audioShoot;

    private void Start()
    {
        playerShoot.onShoot += OnShoot;
        playerMovement.onStartRunning += OnStartRunning;
        playerMovement.onStopRunning += OnStopRunning;
    }

    private void OnShoot()
    {
        playerAnimator.SetTrigger("Shoot");

        int clipToPlay;
        int maxClips = audioClips.Length - 1;

        clipToPlay = Random.Range(0, maxClips);
        audioShoot.clip = audioClips[clipToPlay];
        audioShoot.Play();
        
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
