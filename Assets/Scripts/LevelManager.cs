using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [Header("Spawn Properties")]
    [SerializeField] GameObject World;
    [SerializeField] GameObject BlockPrefab;

    [Header("Level Properties")]
    [SerializeField] float LevelTime = 100f;
    [SerializeField] LevelProperties Settings;

    public int Points { get; private set; }
    private int Level = 1;

    bool RunGame = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Points = 0;
        Level = 1;

        GenerateBlocks();
    }

    private void Update()
    {
        if (RunGame)
        {
            LevelTime -= Time.deltaTime;
            HUD.Instance.UpdateTime(Mathf.RoundToInt(LevelTime));

            //If time's up then end game
            if(LevelTime <= 0)
            {
                RunGame = false;
                EndLevel();
            }
        }
    }

    private void GenerateBlocks()
    {
        float range = (Settings.Size * 5) - 1;
        for (int i = 0; i < Settings.Size * 10; i++)
        {
            GameObject newObj = Instantiate(BlockPrefab, World.transform);
            newObj.transform.position = new Vector3(Random.Range(-range, range), 0.5f, Random.Range(-range, range));
        }
    }

    private void CheckPoints()
    {
        //Grow hole everytime it reaches its target points
        if(Points % (Level * 10) == 0)
        {
            Level++;
            StartCoroutine(HoleManager.Instance.LevelUpHole());
        }
    }

    private void EndLevel()
    {
        HUD.Instance.ShowResultScreen(true);
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
        HUD.Instance.UpdatePoints(Points);
        CheckPoints();
    }

    public void GenerateMap()
    {
        HoleManager.Instance.CreateMap(Settings.Size, Settings.MapColor);
    }

    public LevelProperties GetSettings()
    {
        return Settings;
    }
}
