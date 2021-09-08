using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjChangeColor : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] Animator animator;

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
                OnChangeState();
            }

            if (other.CompareTag("FlyerRed"))
            {
                material = red;
                OnChangeState();
            }

            renderer.material = material;
        }

        if (material == blue)
        {
            if (other.CompareTag("FlyerRed"))
            {
                material = basic;
                OnChangeState();
            }

            renderer.material = material;

        }

        if (material == red)
        {
            if (other.CompareTag("FlyerBlue"))
            {
                material = basic;
                OnChangeState();
            }

            renderer.material = material;
        }
    }

    private void OnChangeState()
    {
        animator.SetTrigger("TractHit");
        ShakeManager.getInstance().Shake(changeStateShake);
        HitstopManager.getInstance().PlayHitStop(changeStateHitstop);
    }

}
