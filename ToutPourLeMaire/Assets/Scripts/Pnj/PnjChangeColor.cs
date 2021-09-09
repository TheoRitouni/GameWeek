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

    private GameObject hudGameObject;
    private HudGame hudgame;

    // Start is called before the first frame update
    void Start()
    {
        material = renderer.material;
        basic = material;

        hudGameObject = GameObject.FindGameObjectWithTag("HUD");
        hudgame = hudGameObject.GetComponent<HudGame>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (material == basic)
        {
            if (other.CompareTag("FlyerBlue"))
            {
                material = blue;
                OnChangeState();
                hudgame.countBluePnj++;
            }

            if (other.CompareTag("FlyerRed"))
            {
                material = red;
                OnChangeState();
                hudgame.countRedPnj++;
            }

            renderer.material = material;
        }

        if (material == blue)
        {
            if (other.CompareTag("FlyerRed"))
            {
                material = basic;
                OnChangeState();
                hudgame.countBluePnj--;

            }

            renderer.material = material;

        }

        if (material == red)
        {
            if (other.CompareTag("FlyerBlue"))
            {
                material = basic;
                OnChangeState();
                hudgame.countRedPnj--;
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
