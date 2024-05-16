using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int relocationCount;
    public int countText;
    public Vector3 playerPosition;
    public Vector3 agentPosition;
    public Vector3 objectToRelocatePosition;

    public GameData()
    {
        this.countText = 0;
        this.relocationCount = 0;
        playerPosition = new Vector3(50.523f, 7.424f, 50.631f);
        agentPosition = new Vector3(67.79f, 1.776f, 79.06f);
        objectToRelocatePosition = new Vector3(49.175f, 6.258f, 52.478f);
    }

    public void ResetAgentPosition(Vector3 newPosition)
    {
        agentPosition = newPosition;
    }
}
