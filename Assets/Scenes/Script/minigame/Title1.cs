using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("test");
        }
    }
}
