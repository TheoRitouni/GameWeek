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

    private int colorInt = 0;
    private string colorType = "basic";

    [Header("Data")]
    [SerializeField] private HitstopData changeStateHitstop;
    [SerializeField] private ShakeData changeStateShake;

    [Header("Renderer")]
    [SerializeField] private Renderer renderer;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;

    [SerializeField] private GameObject tractCollider;


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
        if(tractCollider.tag != other.tag)
        {
            
            if (colorInt == 0)
            {
                //Set Blue
                if (other.CompareTag("FlyerBlue"))
                {
                    colorInt = 1;

                    ChangeColor(blueColor);

                    OnChangeState();
                    hudgame.countBluePnj++;
                }
                //Set Red
                if (other.CompareTag("FlyerRed"))
                {
                    colorInt = 2;

                    ChangeColor(redColor);

                    OnChangeState();
                    hudgame.countRedPnj++;
                }

                renderer.material = material;
            }
            //Set Basic
            if (colorInt == 1)
            {
                if (other.CompareTag("FlyerRed"))
                {
                    colorInt = 0;

                    ChangeColor(basicColor);
                    Debug.Log(basicColor);

                    OnChangeState();
                    hudgame.countBluePnj--;

                }

                renderer.material = material;

            }
            //Set Basic
            if (colorInt == 2)
            {
                if (other.CompareTag("FlyerBlue"))
                {
                    colorInt = 0;

                    ChangeColor(basicColor);
                    Debug.Log(basicColor);

                    OnChangeState();
                    hudgame.countRedPnj--;
                }

                renderer.material = material;
            }
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

    private void ChangeColor(Color colorToAssign)
    {
        MeshRenderer[] children = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer rend in children)
        {
            foreach (Material mat in rend.materials)
            {
                mat.SetColor("_FilterColor", colorToAssign);
            }
        }

        Material[] mats = skinnedMeshRenderer.materials;
        mats[0].SetColor("_FilterColor", colorToAssign);
        skinnedMeshRenderer.materials = mats;
    }


}
