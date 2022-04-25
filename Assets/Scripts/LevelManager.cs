using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [Header("Level Stats")]
    [SerializeField] HUD HUD;
    [SerializeField] HoleManager HoleManager;

    int Points = 0;
    int Level = 1;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Points = 0;
    }

    public void AddPoints(int amount)
    {
        Points += amount;
        HUD.UpdatePoints(Points);
        CheckPoints();
    }

    void CheckPoints()
    {
        if(Points % (Level * 10) == 0)
        {
            Level++;
            HoleManager.LevelUpHole();
        }
    }
}
