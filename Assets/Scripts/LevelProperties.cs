using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelProperties
{
    [Tooltip("Use this to adjust the size of the map")]
    [Range(0, 10)]
    public int Size = 1;

    public Color MapColor;
}
