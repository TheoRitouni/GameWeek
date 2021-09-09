using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjChangeColor : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] AudioSource sourceHit;
    [SerializeField] AudioClip[] clipsHit;

    [Header("Animator")]
    [SerializeField] Animator animator;

    [Header("Colors")]
    [SerializeField] Color basicColor;
    [SerializeField] Color blueColor;
    [SerializeField] Color redColor;

    [Header("Data")]
    [SerializeField] private HitstopData changeStateHitstop;
    [SerializeField] private ShakeData changeStateShake;

    [SerializeField] private Material red;
    [SerializeField] private Material blue;

    [Header("Renderer")]
    [SerializeField] private Renderer renderer;
    
    private Material basic;
    private Material material;

    public System.Action<Color> onChangeColor;

    private GameObject hudGameObject;
    private HudGame hudgame;

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
            //Set Blue
            if (other.CompareTag("FlyerBlue"))
            {
                onChangeColor?.Invoke(blueColor);
                OnChangeState();
                hudgame.countBluePnj++;
            }
            //Set Red
            if (other.CompareTag("FlyerRed"))
            {
                onChangeColor?.Invoke(redColor);
                OnChangeState();
                hudgame.countRedPnj++;
            }

            renderer.material = material;
        }
        //Set Basic
        if (material == blue)
        {
            if (other.CompareTag("FlyerRed"))
            {
                onChangeColor?.Invoke(basicColor);
                OnChangeState();
                hudgame.countBluePnj--;

            }

            renderer.material = material;

        }
        //Set Basic
        if (material == red)
        {
            if (other.CompareTag("FlyerBlue"))
            {
                onChangeColor?.Invoke(basicColor);
                OnChangeState();
                hudgame.countRedPnj--;
            }

            renderer.material = material;
        }
    }

    private void OnChangeState()
    {
        sourceHit.clip = clipsHit[Random.Range(0, clipsHit.Length - 1)];
        sourceHit.Play();

        animator.SetTrigger("TractHit");
        ShakeManager.getInstance().Shake(changeStateShake);
        HitstopManager.getInstance().PlayHitStop(changeStateHitstop);
    }

}
