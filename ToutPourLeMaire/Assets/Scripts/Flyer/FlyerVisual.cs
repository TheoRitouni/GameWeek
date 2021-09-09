using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerVisual : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource_PileTaken;
    [SerializeField] private AudioClip[] audio_PileTaken;

    [SerializeField] private ParticleSystem ps_PileTaken;
    [SerializeField] private GameObject mesh_Pile;

    public void OnFlyerPileTake()
    {
        audioSource_PileTaken.clip = audio_PileTaken[Random.Range(0, audio_PileTaken.Length - 1)];
        audioSource_PileTaken.Play();

        ps_PileTaken.Play();
        mesh_Pile.SetActive(false);

        Invoke("DestroyPile", 0.8f);
    } 

    private void DestroyPile()
    {
        Destroy(gameObject);
    } 
}
