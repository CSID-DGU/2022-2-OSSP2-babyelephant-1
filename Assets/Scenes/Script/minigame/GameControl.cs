using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private Text gameText;
    [SerializeField]
    private SpriteRenderer whiteRect;
    private float reactionTime, startTime, randomDelayBeforeMeasuaring;

    private bool clockIsTicking;
    private bool timerCanBeStopped;


    // Start is called before the first frame update
    void Start()
    {
        reactionTime = 0f;
        startTime = 0f;
        randomDelayBeforeMeasuaring = 0f;
        gameText.text = "코순이를 잡아라!\n 클릭하여 시작";
        clockIsTicking = false;
        timerCanBeStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!clockIsTicking)
            {
                StartCoroutine("StartMeasuring");
                gameText.text = "코순이가 사라지면 빨리 클릭하세요!";
                whiteRect.color = Color.white;
                clockIsTicking = true;
                timerCanBeStopped = false;
            }
            else if(clockIsTicking&&timerCanBeStopped)
            {
                StopCoroutine("StartMeasuring");
                reactionTime = Time.time - startTime;
                if (reactionTime<0.2)
                {
                    gameText.text = reactionTime.ToString("N3") + "초\n" + "코순이를 잡았습니다!\n";
                    PlayerStat.instance.currentMuscle += 10;
                    PlayerStat.instance.currentCharm += 3;
                    PlayerStat.instance.currentHp -= 10;
                    PlayerStat.instance.week += 1;

                }
                else
                {
                    gameText.text = reactionTime.ToString("N3") + "초\n" + "코순이는 이미 떠났습니다..\n다시하려면 클릭";
                }
                //gameText.text = "코순이가 사라진지:\n" + reactionTime.ToString("N3") + "초\n" + "다시하려면 클릭";
                clockIsTicking = false;
            }
            else if(clockIsTicking&&!timerCanBeStopped)
            {
                StopCoroutine("StartMeasuring");
                reactionTime = 0f;
                clockIsTicking = false;
                timerCanBeStopped = true;
                gameText.text = "코순이는 아직 있습니다.\n 코순이를 귀찮게 하지마세요.\n" + "다시하려면 클릭";
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("test");
        }

    }
    private IEnumerator StartMeasuring()
    {
        randomDelayBeforeMeasuaring = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomDelayBeforeMeasuaring);
        whiteRect.color = Color.clear;
        startTime = Time.time;
        clockIsTicking = true;
        timerCanBeStopped = true;
    }
}
