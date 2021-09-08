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
    public Action onShootFailed;

    [Space]
    [Header("Flyer")]
    [SerializeField] private int startFlyer = 15;
    [SerializeField] private int maxFlyer = 20;
    private int flyerRemaining;

    // Start is called before the first frame update
    void Start()
    {
        flyerRemaining = startFlyer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnShoot()
    {
        if (flyerRemaining >= 1)
        {
            if (tag == "PlayerB")
                Instantiate(flyerBulletBlue, flyerSpawner.transform.position, transform.rotation);

            if (tag == "PlayerR")
                Instantiate(flyerBulletRed, flyerSpawner.transform.position, transform.rotation);

            onShoot?.Invoke();

            flyerRemaining--;
        }
        else if(flyerRemaining == 0)
        {
            onShootFailed?.Invoke();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PileFlyers"))
        {
            flyerRemaining += other.GetComponent<ReloadFlyers>().reloadFlyer;
            
            if (flyerRemaining > maxFlyer)
                flyerRemaining = maxFlyer;

            Destroy(other.gameObject);


        }
    }
}
