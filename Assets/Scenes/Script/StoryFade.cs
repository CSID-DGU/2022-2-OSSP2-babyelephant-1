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

    // 흰색->투명
    void PlayFadeIn()
    {
        // 경과 시간 계산.  
        // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
        time += Time.deltaTime / animTime;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = fadeImage.color;
        // 알파 값 계산.  
        color.a = Mathf.Lerp(start, end, time);
        // 계산한 알파 값 다시 설정.  
        fadeImage.color = color;
        // Debug.Log(time);
    }

    // 투명->흰색
    void PlayFadeOut()
    {
        // 경과 시간 계산.  
        // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
        time += Time.deltaTime / animTime;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = fadeImage.color;
        // 알파 값 계산.  
        color.a = Mathf.Lerp(end, start, time);  //FadeIn과는 달리 start, end가 반대다.
        // 계산한 알파 값 다시 설정.  
        fadeImage.color = color;
    }


}
