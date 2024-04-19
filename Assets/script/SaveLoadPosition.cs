using UnityEngine;

public class SaveLoadPosition : MonoBehaviour
{
    private string saveKey = "PlayerPosition";

    // Save the player position
    public void SavePosition(Vector3 position)
    {
        PlayerPrefs.SetFloat(saveKey + "X", position.x);
        PlayerPrefs.SetFloat(saveKey + "Y", position.y);
        PlayerPrefs.SetFloat(saveKey + "Z", position.z);
        PlayerPrefs.Save();
    }

    // Load the player position
    public Vector3 LoadPosition()
    {
        float x = PlayerPrefs.GetFloat(saveKey + "X", 0f);
        float y = PlayerPrefs.GetFloat(saveKey + "Y", 0f);
        float z = PlayerPrefs.GetFloat(saveKey + "Z", 0f);
        return new Vector3(x, y, z);
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
