using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject managerGameObject = new GameObject("GameManager");
                    _instance = managerGameObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    // Example variables to manage game state
    private int currentScore = 0;
    private Vector3 playerPosition = Vector3.zero;

    // Example methods to manage game state
    public int GetCurrentScore()
    {
        return currentScore;
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }

    public void SetCurrentScore(int score)
    {
        currentScore = score;
    }

    public void SetPlayerPosition(Vector3 position)
    {
        playerPosition = position;
    }
}