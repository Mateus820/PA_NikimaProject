using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    // Use this for initialization
    float seconds;
    int minutes;
    [SerializeField] Text timeUI;
    int secondsUI;


    void Start()
    {
        minutes = 3;
        seconds = 60f;       
        secondsUI = 0;
    }

    // Update is called once per frame
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


    }
}
