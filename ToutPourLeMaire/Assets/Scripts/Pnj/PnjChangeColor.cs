using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjChangeColor : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private HitstopData changeStateHitstop;
    [SerializeField] private ShakeData changeStateShake;

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

    private void OnTriggerEnter(Collider other)
    {
        if (material == basic)
        {
            if (other.CompareTag("FlyerBlue"))
            {
                material = blue;
                HitstopManager.getInstance().PlayHitStop(changeStateHitstop);
                ShakeManager.getInstance().Shake(changeStateShake);
            }

            if (other.CompareTag("FlyerRed"))
            {
                material = red;
                HitstopManager.getInstance().PlayHitStop(changeStateHitstop);
                ShakeManager.getInstance().Shake(changeStateShake);
            }

            renderer.material = material;
        }

        if (material == blue)
        {
            if (other.CompareTag("FlyerRed"))
            {
                material = basic;
                HitstopManager.getInstance().PlayHitStop(changeStateHitstop);
                ShakeManager.getInstance().Shake(changeStateShake);
            }

            renderer.material = material;

        }

        if (material == red)
        {
            if (other.CompareTag("FlyerBlue"))
            {
                material = basic;
                HitstopManager.getInstance().PlayHitStop(changeStateHitstop);
            }

            renderer.material = material;
        }
    }
}
