using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider sliderBGM;
    [SerializeField] private Slider sliderEffects;


    public void LoadScene(int value)
    {
        SceneManager.LoadScene(value);
    }

    public void SetBGMVolume()
    {
        mixer.SetFloat("BGMVolume", Mathf.Log10(sliderBGM.value) * 20);
    }

    public void SetEffectsVolume()
    {
        mixer.SetFloat("EffectsVolume", Mathf.Log10(sliderEffects.value) * 20);

    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
