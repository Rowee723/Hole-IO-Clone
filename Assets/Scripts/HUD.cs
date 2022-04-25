using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [Header("Stats Text")]
    [SerializeField] Text Timer;
    [SerializeField] Text Points;

    [Header("Screens")]
    [SerializeField] GameObject MainHUD;
    [SerializeField] GameObject PauseScreen;
    [SerializeField] GameObject ResultScreen;

    private void StopTime(bool stop)
    {
        if (stop)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void UpdateTime(int time)
    {
        Timer.text = "Time: " + time.ToString();
    }

    public void UpdatePoints(int amount)
    {
        Points.text = "Points: " + amount.ToString();
    }

    public void ShowPauseScreen(bool show)
    {
        MainHUD.SetActive(!show);
        PauseScreen.SetActive(show);
        StopTime(show);
    }
    public void ShowResultScreen(bool show)
    {
        MainHUD.SetActive(!show);
        ResultScreen.SetActive(show);
        StopTime(show);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
