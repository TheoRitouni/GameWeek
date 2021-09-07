using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedbacks : MonoBehaviour
{
    [SerializeField] HitstopData hitstopData;
    [SerializeField] ShakeData shakeData;


    private void Start()
    {
        Invoke("OnThrowFlyer", 1f);
    }

    private void OnThrowFlyer()
    {
        ShakeManager.getInstance().Shake(shakeData);
    }
}
