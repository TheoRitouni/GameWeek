using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedbacks : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] GameObject sprite;

    [Header("Scripts")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerShoot playerShoot;

    [Header("Data")]
    [SerializeField] HitstopData hitstopData;
    [SerializeField] ShakeData shakeData;

    [Header("Sounds")]
    [SerializeField] AudioClip[] audioFootsteps;
    [SerializeField] AudioClip[] audioShoots;

    [Header("Audio")]
    [SerializeField] AudioSource audioRun;
    [SerializeField] AudioSource audioShoot;

    [Header("Particles")]
    [SerializeField] ParticleSystem ps_Run;

    private void Start()
    {
        playerShoot.onShoot += OnCharaShoot;
        //playerShoot.onShootFailed += OnShootFailed;
        playerMovement.onStartRunning += OnStartRunning;
        playerMovement.onStopRunning += OnStopRunning;
    }

    private void Update()
    {
        sprite.transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }

    private void OnCharaShoot()
    {
        playerAnimator.SetTrigger("Shoot");

        int maxClips = audioShoots.Length - 1;
        audioShoot.clip = audioShoots[Random.Range(0, maxClips)];
        audioShoot.Play();
        
        ShakeManager.getInstance().Shake(shakeData);
    }

    private void OnStartRunning()
    {
        playerAnimator.SetBool("isRunning", true);
    }

    private void OnStopRunning()
    {
        playerAnimator.SetBool("isRunning", false);
        audioRun.Stop();
    }

    public void PlayRandomFootStepsSound()
    {
        int maxClips = audioFootsteps.Length - 1;
        audioRun.clip = audioFootsteps[Random.Range(0, maxClips)];
        audioRun.Play();

        ps_Run.Play();
    }

}
