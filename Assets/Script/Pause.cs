using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void TogglePause()
    {

        Time.timeScale = 0f; // Pause the game

    }
    public void TogglePlay()
    {
        Time.timeScale = 1f; // Pause the game
    }
}
