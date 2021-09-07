using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject flyerBullet;
    [SerializeField] private GameObject flyerSpawner;

    public Action onShoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnShoot()
    {
        Instantiate(flyerBullet, flyerSpawner.transform.position , transform.rotation);
        onShoot?.Invoke();
    }
}
