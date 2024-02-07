using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTimer : MonoBehaviour
{
    [SerializeField] float answerTime;
    float currentTime;

    [SerializeField] GameObject panelDeTiempo;

    bool isTimerRunning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartTimer()
    {
        isTimerRunning = true;
        RestartTimer();
    }

    void CountDown()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            //isTimerRunning = false;
            print("Se acabo el tiempo");
            GameEvents.HurtPlayer.Invoke();
            RestartTimer();
        }
    }

    void UpdateTimeDisplay()
    {
        panelDeTiempo.GetComponentInChildren<Image>().fillAmount = currentTime / answerTime;
    }

    public void TimerRestart()
    {
        RestartTimer();
    }

    void RestartTimer()
    {
        currentTime = answerTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            CountDown();
            UpdateTimeDisplay();
        }
    }
}
