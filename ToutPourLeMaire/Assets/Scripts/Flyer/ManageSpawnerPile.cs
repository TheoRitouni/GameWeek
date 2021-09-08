using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSpawnerPile : MonoBehaviour
{
    [SerializeField] private float timerSpawn = 10f;
    private float saveTimerSpawn;
    // Start is called before the first frame update
    void Start()
    {
        saveTimerSpawn = timerSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timerSpawn -= Time.deltaTime;

        if(timerSpawn <= 0)
        {
            timerSpawn = saveTimerSpawn;

            var spawnerPiles = GameObject.FindObjectsOfType<SpawnPileOfFlyers>();
            int randomSpawner = Random.Range(0, spawnerPiles.Length);

            spawnerPiles[randomSpawner].SpawnOne();
        }
        
    }
}
