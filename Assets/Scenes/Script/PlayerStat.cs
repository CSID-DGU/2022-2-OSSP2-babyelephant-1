using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat instance;

    [SerializeField]
    private Text DayText;

    public int year;
    public int week;
    public int count;

    public int Hp;
    public int currentHp;

    public int Learning;
    public int currentLearning;

    public int Faith;
    public int currentFaith;

    public int Muscle;
    public int currentMuscle;

    public int Art;
    public int currentArt;

    public int Charm;
    public int currentCharm;

    public Slider Slider1;
    public Slider Slider2;
    public Slider Slider3;
    public Slider Slider4;
    public Slider Slider5;
    public Slider Slider6;

    // Start is called before the first frame update
    void Start()
    {
        DayText.text = "1학년 1학기 1주차";
        week = 1;
        year = 1;
        instance = this;
        currentHp = 100;
        currentLearning = 0;
        currentFaith = 0;
        currentMuscle = 0;
        currentArt = 0;
        currentCharm = 0;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Slider1.maxValue = Hp;
        Slider2.maxValue = Learning;
        Slider3.maxValue = Faith;
        Slider4.maxValue = Muscle;
        Slider5.maxValue = Art;
        Slider6.maxValue = Charm;

        Slider1.value = currentHp;
        Slider2.value = currentLearning;
        Slider3.value = currentFaith;
        Slider4.value = currentMuscle;
        Slider5.value = currentArt;
        Slider6.value = currentCharm;   

        if (week > 51)
        {
            year += 1;
            week -= 51;
        }
        else
        {
            if (week > 25)
            {
                DayText.text = year.ToString() + "학년 " + "2학기 " +week.ToString() + "주차";
            }
            else
            {
                DayText.text = year.ToString() + "학년 " + "1학기 " + week.ToString() + "주차";
            }
        }
        if (count==0 && year > 4)
        {
            count = 1;
            if (PlayerStat.instance.currentLearning > 250)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("startStory 2");
            }
            else if (PlayerStat.instance.currentFaith > 250)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("startStory 4");
            }
            else if (PlayerStat.instance.currentMuscle > 250)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("startStory 1");
            }
            else if (PlayerStat.instance.currentArt> 250)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("startStory 3");
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("startStory 5");
            }
        }
    }
}
