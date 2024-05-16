using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public FieldOfView fieldOfView;

    private void Update()
    {
        if (fieldOfView != null && fieldOfView.IsPlayerVisible())
        {
            // Follow the player
            // For example, you can use transform.Translate or other movement logic here
        }
    }
}
