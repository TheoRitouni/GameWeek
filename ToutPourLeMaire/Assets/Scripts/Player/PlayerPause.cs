using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPause : MonoBehaviour
{
    private bool isGamePause = false;
    private GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI = GameObject.FindGameObjectWithTag("Pause");
        pauseUI.GetComponentInChildren<Canvas>().enabled = true;
        pauseUI.SetActive(isGamePause);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPause()
    {
        if (pauseUI == null)
            return;

        if (isGamePause)
        {
            Time.timeScale = 1f;
            isGamePause = false;
            pauseUI.SetActive(isGamePause);

        }
        else
        {
            Time.timeScale = 0f;
            isGamePause = true;
            pauseUI.SetActive(isGamePause);

        }
    }

    private void OnBack()
    {
        if (isGamePause)
            SceneManager.LoadScene(0);
    }
}
