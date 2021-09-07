using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PnjMovement : MonoBehaviour
{
    [SerializeField] private float wanderRadius;
    [SerializeField] private float wanderTimer;

    private NavMeshAgent agent;
    private float timer;

    [SerializeField] private float timerLife = 15f;

    private bool selectSpawner = false;
    private Vector3 spawnerPos;

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    void Update()
    {

        timerLife -= Time.deltaTime;

        if (timerLife < 0)
        {
            if (!selectSpawner)
            {
                var spawner = GameObject.FindObjectsOfType<SpawnerPnj>();
                int randomSpawner = Random.Range(0, spawner.Length);

                spawnerPos = spawner[randomSpawner].transform.position;

                agent.SetDestination(spawnerPos);

                selectSpawner = true;
            }

            if ((transform.position - spawnerPos).magnitude <= 2)
                Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
