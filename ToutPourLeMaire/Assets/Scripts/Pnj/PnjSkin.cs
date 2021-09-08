using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjSkin : MonoBehaviour
{
    [Header("Skin")]
    [SerializeField] GameObject[] armatures;
    [SerializeField] Material[] materialsList;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;

    private void Awake()
    {
        //Active Random Armatures
        int armaturesIndexToActive = Random.Range(0, armatures.Length);
        armatures[armaturesIndexToActive].SetActive(true);

        //Active Random Color Skin
        int skinColorIndexToActive = Random.Range(0, materialsList.Length);

        Material material = materialsList[skinColorIndexToActive];
        skinnedMeshRenderer.materials[0] = material;
        Debug.Log(material);
    }



}
