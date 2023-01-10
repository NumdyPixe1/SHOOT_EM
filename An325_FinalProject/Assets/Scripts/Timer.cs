using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public bool isRestart = false;
    public bool isStop = false;
    public TextMeshProUGUI timeText;
    public static float curretTime = 0f;

    void Update()
    {
        StartTime();
        if (isRestart == true)
        {
            curretTime = 0f;
        }
        if (isStop == true)
        {
            enabled = false;
        }
    }
    void StartTime()
    {
        timeText.text = "Time : " + curretTime.ToString("00.00");
        curretTime += 1 * Time.deltaTime;
    }

}