using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPnj : MonoBehaviour
{
    [SerializeField] private float minFreqSpawnPnj = 10f;
    [SerializeField] private float maxFreqSpawnPnj = 20f;
    private float freqSpawnPnj = 0f;

    [SerializeField] private GameObject pnj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        freqSpawnPnj -= Time.deltaTime;

        if(freqSpawnPnj <= 0)
        {
            Instantiate(pnj, gameObject.transform.position, Quaternion.identity);
            freqSpawnPnj = Random.Range(minFreqSpawnPnj, maxFreqSpawnPnj);
        }
    }
}
