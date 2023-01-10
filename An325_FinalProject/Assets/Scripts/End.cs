using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class End : MonoBehaviour
{
    public Timer timer;
    public TextMeshProUGUI youWinText;
    float i;
    void Start()
    {
        youWinText.text = "YOU WIN.";
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer.isStop = true;
            // timer.StartTime();
            youWinText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }


    }
    void Update()
    {

    }
}
