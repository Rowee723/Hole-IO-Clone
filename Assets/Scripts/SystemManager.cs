using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    public static SystemManager Instance { get; private set; }

    private string PlayerName = "";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);
    }

    public void ReadStringInput(string newName)
    {
        PlayerName = newName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
