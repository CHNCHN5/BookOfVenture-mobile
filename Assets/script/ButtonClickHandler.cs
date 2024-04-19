using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public void SaveButtonClicked()
    {
        // Save game data when the button is clicked
        GameData data = new GameData();
        data.score = GameManager.instance.GetCurrentScore();
        // Convert Vector3 to SerializableVector3
        SerializableVector3 serializablePlayerPosition = new SerializableVector3(GameManager.instance.GetPlayerPosition());
        data.playerPosition = serializablePlayerPosition;
        SaveManager.SaveGameData(data);

        Debug.Log("Game data saved. Score: " + data.score + ", Player position: " + data.playerPosition);
    }

    public void LoadButtonClicked()
    {
        // Load game data when the button is clicked
        GameData loadedData = SaveManager.LoadGameData();
        if (loadedData != null)
        {
            // Convert SerializableVector3 back to Vector3
            Vector3 playerPosition = loadedData.playerPosition.ToVector3();
            // Set the loaded score and player position in the game
            GameManager.instance.SetCurrentScore(loadedData.score);
            GameManager.instance.SetPlayerPosition(playerPosition);

            Debug.Log("Game data loaded. Score: " + loadedData.score + ", Player position: " + playerPosition);
        }
        else
        {
            Debug.LogWarning("No saved game data found.");
        }
    }
}
