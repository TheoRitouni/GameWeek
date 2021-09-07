using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerMovement : MonoBehaviour
{

    [SerializeField] private float speedFlyer = 20f;
    [SerializeField] private float maxDistance = 30f;
    [SerializeField] private float distanceSlowspeed = 10f;
    [SerializeField] private float minSpeed = 10f;
    [SerializeField] private float multiplySlow = 2f;

    private Vector3 initialPos;
    private Rigidbody rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = transform.forward * speedFlyer;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, initialPos) > distanceSlowspeed && speedFlyer > minSpeed)
        {
            speedFlyer -= Time.deltaTime * multiplySlow;
            rigidbody.velocity = transform.forward * speedFlyer;
        }

        if (maxDistance < Vector3.Distance(transform.position, initialPos))
            Destroy(gameObject);
    }


}
