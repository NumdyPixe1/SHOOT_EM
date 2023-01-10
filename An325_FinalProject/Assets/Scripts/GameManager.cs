using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public AudioSource audioSource;
    public bool IsWin;
    public bool IsGameOver;
    public GameObject RestartButton;
    public TextMeshProUGUI gameOverText;
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    void BlinkingText()
    {
        StartCoroutine(StartBlinking());
    }
    IEnumerator StartBlinking()
    {
        while (true)
        {
            gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(1f);
            gameOverText.text = "";
            yield return new WaitForSeconds(1f);
        }
    }
    public void QuitgameButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Quitgame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
    public void Restart()
    {
        timer.isRestart = true;
        SceneManager.LoadScene("Level1");
    }
    public void GameOver()
    {
        timer.isStop = true;
        audioSource.Play();
        BlinkingText();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
