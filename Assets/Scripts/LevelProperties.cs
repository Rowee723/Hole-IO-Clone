using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelProperties
{
    [Tooltip("Adjusts the size of the map")]
    [Range(1, 10)]
    public int Size = 1;

    [Tooltip("Adjusts the color of the map")]
    public Color MapColor = Color.white;

    public LevelProperties()
    {
        Size = 1; 
        MapColor = Color.white;
    }
}
