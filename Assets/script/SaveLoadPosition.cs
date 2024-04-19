using UnityEngine;
using System;
using System.IO;

[Serializable]
public class SaveData
{
    public float x;
    public float y;
    public float z;
}

public class SaveLoadPosition : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/save.json";
    }

    // Save the player position
    public void SavePosition(Vector3 position)
    {
        SaveData data = new SaveData
        {
            x = position.x,
            y = position.y,
            z = position.z
        };

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, jsonData);
    }

    // Load the player position
    public Vector3 LoadPosition()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);
            return new Vector3(data.x, data.y, data.z);
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return Vector3.zero;
        }
    }

    // Example usage: Save position when called
    public void SavePlayerPosition()
    {
        SavePosition(transform.position);
    }

    // Example usage: Load position when called
    public void LoadPlayerPosition()
    {
        Vector3 savedPosition = LoadPosition();
        transform.position = savedPosition;
    }
}