using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] PlayerFeedbacks playerFeedbacks;

    public void DoOneStep()
    {
        playerFeedbacks.PlayRandomFootStepsSound();
    }
}
