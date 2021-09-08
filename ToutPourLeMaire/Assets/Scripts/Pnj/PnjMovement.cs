using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PnjMovement : MonoBehaviour
{
    [Space]
    [SerializeField] private float minWanderRadius;
    [SerializeField] private float maxWanderRadius;

    [Space]
    [SerializeField] private float minWanderTimer;
    [SerializeField] private float maxWanderTimer;

    private float wanderRadius;
    private float wanderTimer;

    private NavMeshAgent agent;
    private float timer;

    private float timerLife = 15f;

    [Space]
    [SerializeField] private float minTimerLife;
    [SerializeField] private float maxTimerLife;

    private bool selectSpawner = false;
    private Vector3 spawnerPos;

    [Space]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    void OnEnable()
    {
        wanderRadius = Random.Range(minWanderRadius, maxWanderRadius);
        wanderTimer = Random.Range(minWanderTimer, maxWanderTimer);
        timerLife = Random.Range(minTimerLife, maxTimerLife);

        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

        agent.speed = Random.Range(minSpeed, maxSpeed);
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
                agent.speed = Random.Range(minSpeed, maxSpeed);

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
                agent.speed = Random.Range(minSpeed, maxSpeed);
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
