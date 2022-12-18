using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryFade : MonoBehaviour
{
    public float animTime = 2f;
    public Image fadeImage;

    private float start = 1f;
    private float end = 0f;
    private float time = 0f;


    public bool stopIn = false;
    public bool stopOut = true;

    void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stopIn == false && time <= 2)
        {
            PlayFadeIn();
        }
        if(stopOut == false && time <= 2)
        {
            PlayFadeOut();
        }
        if(time >= 2 && stopIn == false)
        {
            stopIn = true;
            time = 0;
            Debug.Log("StopIn");
        }
        if(time >= 2 && stopOut == false)
        {
            stopOut = true;
            time = 0;
            Debug.Log("StopOut");
            //UnityEngine.SceneManagement.SceneManager.LoadScene("test");
        }
        
    }

    // ���->����
    void PlayFadeIn()
    {
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(start, end, time);
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
        // Debug.Log(time);
    }

    // ����->���
    void PlayFadeOut()
    {
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(end, start, time);  //FadeIn���� �޸� start, end�� �ݴ��.
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
    }


}
