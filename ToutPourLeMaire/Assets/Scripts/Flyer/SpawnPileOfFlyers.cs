using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPileOfFlyers : MonoBehaviour
{
    [SerializeField] private GameObject pilesOfFlyers;

    public void SpawnOne()
    {
        Instantiate(pilesOfFlyers, transform.position, Quaternion.identity);
    }
}
