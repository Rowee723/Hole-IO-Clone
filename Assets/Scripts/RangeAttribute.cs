using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttribute : PropertyAttribute
{
    public int min;
    public int max;

    public RangeAttribute(int min, int max)
    {
        this.min = min;
        this.max = max;
    }
}
