using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyTime : MonoBehaviour
{
    
    public int seconds = 0;
    public int prevSecond = 0;
    int prevTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (prevSecond != seconds)
        {
            prevSecond = seconds;
        }
    }

    void Timer()
    {
        if (Math.Floor(Time.time) > prevTime)
        {
            prevTime = (int)Math.Floor(Time.time);
            seconds++;
            // Debug.Log(seconds);
        }
    }
}
