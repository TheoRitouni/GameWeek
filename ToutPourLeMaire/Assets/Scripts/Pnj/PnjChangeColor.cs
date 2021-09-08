using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjChangeColor : MonoBehaviour
{

    [SerializeField] private Material red;
    [SerializeField] private Material blue;

    [SerializeField] private Renderer renderer;
    
    private Material basic;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = renderer.material;
        basic = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(material);

        if (material == basic)
        {
            if (other.CompareTag("FlyerBlue"))
                material = blue;

            if (other.CompareTag("FlyerRed"))
                material = red;

            renderer.material = material;
        }

        if (material == blue)
        {
            if (other.CompareTag("FlyerRed"))
                material = basic;

            renderer.material = material;

        }

        if (material == red)
        {
            if (other.CompareTag("FlyerBlue"))
                material = basic;

            renderer.material = material;

        }
    }
}
