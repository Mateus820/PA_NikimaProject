using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCount : MonoBehaviour {

    public AudioSource audioSource;
    public BallShot ballShot;
    public float velocitySwap;
    float seconds, totalSeconds, variance;
    int minutes;
    int secondsUI;
    [SerializeField] Text timeUI;

    void Start()
    {
        minutes = 3;
        seconds = 46f;       
        secondsUI = 0;
        totalSeconds = minutes * 60f + seconds;
        variance = ballShot.Variance();
        StartCoroutine(VelocitySwap());
    }

    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <= 0)
        {
            minutes -= 1;
            seconds = 60f;
        }
        secondsUI = (int)seconds;
        if (seconds >= 10)
        {
            timeUI.text = minutes.ToString() + ":" + secondsUI.ToString();
        }
        else
        {
            timeUI.text = minutes.ToString() + ":0" + secondsUI.ToString();
        }
        
        if(minutes <= 0 && seconds <= 0){
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
    }

    private float AllSeconds()
    {
        float final = minutes * 60f;
        final += seconds;
        return final;
    }    
    IEnumerator VelocitySwap()
    {
        while(true)
        {
            yield return new WaitForSeconds(velocitySwap);
            ballShot.ColorChangeSpeed(velocitySwap * (variance/totalSeconds));
        }
    }
}

