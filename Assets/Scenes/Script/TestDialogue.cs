using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{

    [SerializeField]
    public Dialogue dialogue;

    private DialogueManager theDM;
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theDM.talking = false;

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (theDM.talking == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (collision.gameObject.name == "Player")
                {
                    theDM.ShowDialogue(dialogue);
                }
            }
            
        }
    }
}
