using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float TimeDuration = 30f;
    public float timeRemaining;
    public bool timerRunning;

    void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        timeRemaining = TimeDuration;
        timerRunning = true;
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = $"[{Mathf.CeilToInt(timeRemaining)}]";
            yield return null;
        }

        timerRunning = false;
        TimerEnded();
    }

    private void TimerEnded()
    {
        Debug.Log("Timer ended!");
        timerText.text = "Time's Up!";
    }

}
