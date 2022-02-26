using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TimerSystem : MonoBehaviour
{
    public string Timer = @"00:00";
    private bool IsPlaying = true;
    public float TotalSeconds = 5 * 60;
    public Text Text;

    private void Start()
    {
        Timer = CountdownTimer(false);
    }

    private void Update()
    {
        if (IsPlaying)
        {
            Timer = CountdownTimer();
        }

        if (TotalSeconds <= 0)
        {
            SetZero();
        }

        if (Text)
        {
            Text.text = Timer;
        }
    }

    private string CountdownTimer(bool IsUpdate = true)
    {
        if (IsUpdate)
            TotalSeconds -= Time.deltaTime;

        TimeSpan timespan = TimeSpan.FromSeconds(TotalSeconds);
        string timer = string.Format("{0:00}:{1:00}", 
            timespan.Minutes, timespan.Seconds);

        return timer;
    }

    private void SetZero()
    {
        Timer = @"00:00";
        TotalSeconds = 0;
        IsPlaying = false;
        SceneManager.LoadScene("Fail_End");
    }
}
