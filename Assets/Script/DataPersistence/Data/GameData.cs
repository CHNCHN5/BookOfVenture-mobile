using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int relocationCount;
    public Vector3 playerPosition;

    public GameData()
    {
        this.relocationCount = 0;
        playerPosition = new Vector3(50.523f, 7.424f, 50.631f);
    }
}
