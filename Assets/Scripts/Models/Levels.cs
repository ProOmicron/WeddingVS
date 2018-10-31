using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Levels
{
    public Level[] levels;

    [System.Serializable]
    public class Level
    {
        public int difficulty;
        public Color color;
    }
}
