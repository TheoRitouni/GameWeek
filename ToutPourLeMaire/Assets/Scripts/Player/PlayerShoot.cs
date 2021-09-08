using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject flyerBulletBlue;
    [SerializeField] private GameObject flyerBulletRed;


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
        if (tag == "PlayerB")
            Instantiate(flyerBulletBlue, flyerSpawner.transform.position , transform.rotation);

        if (tag == "PlayerR")
            Instantiate(flyerBulletRed, flyerSpawner.transform.position, transform.rotation);

        onShoot?.Invoke();
    }
}
