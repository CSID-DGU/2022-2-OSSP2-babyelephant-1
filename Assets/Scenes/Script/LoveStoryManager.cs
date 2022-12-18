using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveStoryManager : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;
    public StoryFade storyfade;


    public Text text;
    public SpriteRenderer rendererDialogueWindow;

    private List<string> listSentences;
    private List<Sprite> listDialogueWindows;

    private int count; // 대화 진행 상황 카운트

    public Animator animDialogueWindow;
    public Animator animFlower;

    public bool talking = false;

    // Start is called before the first frame update
    void Start()
    {
        storyfade = FindObjectOfType<StoryFade>();
        count = 0;
        text.text = "";
        listSentences = new List<string>();
        listDialogueWindows = new List<Sprite>();
        ShowDialogue(dialogue);

    }

    public void ShowDialogue(Dialogue dialogue)
    {

        talking = true;
        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            listSentences.Add(dialogue.sentences[i]);
            listDialogueWindows.Add(dialogue.dialogueWindows[i]);
        }
        animDialogueWindow.SetBool("Appear", true);
        StartCoroutine(StartDialogueCoroutine());

    }

    public void ExitDialogue()
    {
        text.text = "";
        count = 0;
        listSentences.Clear();
        listDialogueWindows.Clear();
        animDialogueWindow.SetBool("Appear", false);
        talking = false;
    }

    IEnumerator StartDialogueCoroutine()
    {
        if (count > 0)
        {
            if (listDialogueWindows[count] != listDialogueWindows[count - 1])
            {
                animDialogueWindow.SetBool("Appear", false);
                yield return new WaitForSeconds(0.05f);
                rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
                animDialogueWindow.SetBool("Appear", true);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
            }

        }
        else
        {
            rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
        }



        for (int i = 0; i < listSentences[count].Length; i++)
        {
            text.text += listSentences[count][i]; // 문장에서 한 글자씩 출력
            yield return new WaitForSeconds(0.1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (talking)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                count++;
                text.text = "";

                if (count == listSentences.Count)
                {
                    StopAllCoroutines();
                    ExitDialogue();
                    storyfade.stopOut = false;
                    // 나중에 시작화면으로 돌아가게 하기!
                }
                else if(count == 6)
                {
                    StopAllCoroutines();
                    animFlower.SetBool("Pass", true);
                    StartCoroutine(StartDialogueCoroutine());
                }
                else
                {
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());
                }
            }
        }
    }

}
