using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    float seconds;
    int minutes;
    int secondsUI;
    [SerializeField] Text timeUI;

    void Start()
    {
        minutes = 3;
        seconds = 46f;       
        secondsUI = 0;
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
}
