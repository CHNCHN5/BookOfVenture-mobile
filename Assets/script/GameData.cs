using UnityEngine;

[System.Serializable]
public class GameData
{
    // Add variables here for data you want to save
    public int score;
    public SerializableVector3 playerPosition; // Use SerializableVector3 instead of Vector3
    // Add more as needed
}
