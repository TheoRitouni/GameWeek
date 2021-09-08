﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadFlyers : MonoBehaviour
{
    [SerializeField] private float lifeTimer = 5f;
    [SerializeField] public int reloadFlyer = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
            Destroy(gameObject);
    }

}