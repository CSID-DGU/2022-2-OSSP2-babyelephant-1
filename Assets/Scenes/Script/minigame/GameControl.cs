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
        gameText.text = "�ڼ��̸� ��ƶ�!\n Ŭ���Ͽ� ����";
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
                gameText.text = "�ڼ��̰� ������� ���� Ŭ���ϼ���!";
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
                    gameText.text = reactionTime.ToString("N3") + "��\n" + "�ڼ��̸� ��ҽ��ϴ�!\n";
                    PlayerStat.instance.currentMuscle += 10;
                    PlayerStat.instance.currentCharm += 3;
                    PlayerStat.instance.currentHp -= 10;
                    PlayerStat.instance.week += 1;

                }
                else
                {
                    gameText.text = reactionTime.ToString("N3") + "��\n" + "�ڼ��̴� �̹� �������ϴ�..\n�ٽ��Ϸ��� Ŭ��";
                }
                //gameText.text = "�ڼ��̰� �������:\n" + reactionTime.ToString("N3") + "��\n" + "�ٽ��Ϸ��� Ŭ��";
                clockIsTicking = false;
            }
            else if(clockIsTicking&&!timerCanBeStopped)
            {
                StopCoroutine("StartMeasuring");
                reactionTime = 0f;
                clockIsTicking = false;
                timerCanBeStopped = true;
                gameText.text = "�ڼ��̴� ���� �ֽ��ϴ�.\n �ڼ��̸� ������ ����������.\n" + "�ٽ��Ϸ��� Ŭ��";
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
