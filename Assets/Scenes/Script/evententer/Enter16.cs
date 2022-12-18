using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter16 : MonoBehaviour
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("wonhong_sleep");
                PlayerStat.instance.currentHp += 10;
                PlayerStat.instance.week += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
