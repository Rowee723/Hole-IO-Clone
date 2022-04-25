using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStats : MonoBehaviour
{
    [Header("Block Stats")]
    [SerializeField] int Points = 1;

    public int GetPoints()
    {
        return Points;
    }
}
