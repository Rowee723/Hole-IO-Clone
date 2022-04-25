using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("Stats Text")]
    [SerializeField] Text Name;
    [SerializeField] Text Points;

    public void UpdatePoints(int amount)
    {
        Points.text = "Points: " + amount.ToString();
    }
}
