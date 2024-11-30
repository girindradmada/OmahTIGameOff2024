using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

class compare : IComparer<HighscoreElement>
{
    public int Compare(HighscoreElement a, HighscoreElement b)
    {
        // Compare x to y
        return b.points.CompareTo(a.points);
    }
}