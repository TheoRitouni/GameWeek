using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjSkin : MonoBehaviour
{
    [SerializeField] GameObject[] armatures;
    [SerializeField] Material[] materials;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;

    private void Start()
    {
        //Active Random Armatures
        int armaturesIndexToActive = Random.Range(0, armatures.Length - 1);
        armatures[armaturesIndexToActive].SetActive(true);

        //Active Random Color Skin
        int skinColorIndexToActive = Random.Range(0, materials.Length - 1);
        skinnedMeshRenderer.materials[0] = materials[skinColorIndexToActive];
        //skinnedMeshRenderer.material = materials[skinColorIndexToActive];
    }

}
