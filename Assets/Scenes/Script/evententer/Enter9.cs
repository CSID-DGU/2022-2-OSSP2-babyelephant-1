using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter9 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (PlayerStat.instance.currentHp > 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("libraryevent");
                PlayerStat.instance.currentLearning += 5;
                PlayerStat.instance.currentCharm += 1;
                PlayerStat.instance.currentHp -= 5;
                PlayerStat.instance.week += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
