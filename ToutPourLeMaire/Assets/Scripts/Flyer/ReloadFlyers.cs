using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadFlyers : MonoBehaviour
{
    [SerializeField] private float lifeTimer = 5f;
    [SerializeField] public int reloadFlyer = 10;

    void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
            Destroy(gameObject);
    }

}
