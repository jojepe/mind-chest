using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    public static Action OnDayChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }
    
    public static int Day { get; private set; }

    private float minuteToRealTime = 0.05f;
    private float timer;
    void Start()
    {
        Minute = 0;
        Hour = 8;
        Day = 0;
        timer = minuteToRealTime;
    }
    
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Minute++;
            OnMinuteChanged?.Invoke();
            if (Minute >= 60)
            {
                Hour++;
                Minute = 0;
                OnHourChanged?.Invoke();
            }

            if (Hour >= 20)
            {
                Day++;
                Hour = 8;
                OnDayChanged?.Invoke();
            }

            timer = minuteToRealTime;
        }
    }
}
