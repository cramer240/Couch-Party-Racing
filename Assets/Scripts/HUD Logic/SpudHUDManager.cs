﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpudHUDManager : MonoBehaviour {

    private float boost;
    private string poweruptype;
    public GameObject kart;
    public GameObject potato;
    public Text boostText;
    public Text timerText;
    List<float> seconds;
    List<int> minutes;

    public Text timeRemainingText;
    List<float> secondsRemain;
    List<int> minutesRemain;

    // Use this for initialization
    void Start()
    {
        seconds = new List<float>();
        minutes = new List<int>();
        seconds.Add(0f);
        minutes.Add(0);

        secondsRemain = new List<float>();
        minutesRemain = new List<int>();
        secondsRemain.Add(60f);
        minutesRemain.Add(0);
    }

    // Update is called once per frame
    void Update()
    {
        boost = kart.GetComponent<Kart>().Boost;
        boostText.text = ((int)boost).ToString();
        poweruptype = kart.GetComponent<Kart>().Powerup;

        if (potato.GetComponent<SpudScript>().IsTagged)
        {
            UpdateTimerUI(kart, 0);
        }
        
    }


    public void UpdateTimerUI(GameObject kart, int kartNumber)
    {
        string minuteText;
        string secondsText;
        string minuteRemainText;
        string secondsRemainText;
        seconds[kartNumber] += Time.deltaTime;
        secondsRemain[kartNumber] -= Time.deltaTime;

        if (seconds[kartNumber] < 10)
        {
            secondsText = "0" + seconds[kartNumber].ToString("F2");
            secondsRemainText = secondsRemain[kartNumber].ToString("F2");
        }
        else
        {
            secondsText = seconds[kartNumber].ToString("F2");
            secondsRemainText = secondsRemain[kartNumber].ToString("F2");
        }

        if (minutes[kartNumber] < 10)
        {
            minuteText = "0" + minutes[kartNumber];
            minuteRemainText = "0" + minutesRemain[kartNumber];
        }
        else
        {
            minuteText = minutes[kartNumber].ToString();
            minuteRemainText = minutesRemain[kartNumber].ToString();
        }
        string timeDisplay = minuteText + ":" + secondsText;
        string timeRemainDisplay = minuteRemainText + ":" + secondsRemainText;

        if (kartNumber == 0)
        {
            kart.GetComponent<Kart>().TimeText = timeDisplay;
            potato.GetComponent<SpudScript>().TimeRemaining = timeRemainDisplay;
            timerText.text = timeDisplay;
            timeRemainingText.text = timeRemainDisplay;
        }
        else
        {
            kart.GetComponent<WaypointAI>().TimeText = timeDisplay;
        }

        if (seconds[kartNumber] >= 60)
        {
            minutes[kartNumber]++;
            seconds[kartNumber] = 0;
            minutesRemain[kartNumber]++;
            secondsRemain[kartNumber] = 0;
        }
    }
}