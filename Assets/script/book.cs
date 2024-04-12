using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{
    public GameObject ActivateC;
    public GameObject DeactivateC;
    public MonoBehaviour DeactScript;

    public void DeactivateDesiredScript()
    {
        if (DeactScript != null)
        {
            DeactScript.enabled = false;
            Debug.Log("Script '" + DeactScript.GetType().Name + "' deactivated.");
        }
        else
        {
            Debug.LogWarning("No script assigned to deactivate.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Book"))
        {
            ActivateC.SetActive(true);
            DeactivateC.SetActive(false);
            DeactivateDesiredScript();
            mouse();
        }

        
    }
    void mouse()
    {
        Cursor.visible = (ActivateC);
    }

}
