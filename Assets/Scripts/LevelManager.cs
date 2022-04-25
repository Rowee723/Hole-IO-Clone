using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [Header("Managers")]
    [SerializeField] HUD HUDManager;
    [SerializeField] HoleManager HoleManager;

    [Header("Level Properties")]
    [SerializeField] float LevelTime = 100f;
    [SerializeField] LevelProperties Properties;

    int Points = 0;
    int Level = 1;

    bool RunGame = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Points = 0;
        Level = 1;
    }

    private void Update()
    {
        if (RunGame)
        {
            LevelTime -= Time.deltaTime;
            HUDManager.UpdateTime(Mathf.RoundToInt(LevelTime));

            //If time's up then end game
            if(LevelTime <= 0)
            {
                RunGame = false;
                EndLevel();
            }
        }
    }

    private void CheckPoints()
    {
        //Grow hole everytime it reaches its target points
        if(Points % (Level * 10) == 0)
        {
            Level++;
            StartCoroutine(HoleManager.LevelUpHole());
        }
    }

    private void EndLevel()
    {
        HUDManager.ShowResultScreen(true);
    }

    public void StartLevel()
    {
        RunGame = true;
    }

    public bool IsGameRunning()
    {
        return RunGame;
    }

    public void AddPoints(int amount)
    {
        Points += amount;
        HUDManager.UpdatePoints(Points);
        CheckPoints();
    }
}
