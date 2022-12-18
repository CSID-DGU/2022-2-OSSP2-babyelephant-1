using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTitle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("startStory");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {
    }
}
