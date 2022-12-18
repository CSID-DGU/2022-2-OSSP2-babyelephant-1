using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter3 : MonoBehaviour
{
    private static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (count == 0) {
                count += 1;
                UnityEngine.SceneManagement.SceneManager.LoadScene("start");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
