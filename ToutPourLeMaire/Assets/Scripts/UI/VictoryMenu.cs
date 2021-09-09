using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int value)
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(value);
    }

    public void UnLoadAndLoadScene(int value)
    {
        SceneManager.UnloadSceneAsync(value);
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(value);
    }

    private void OnPause()
    { print("salut"); }
}
