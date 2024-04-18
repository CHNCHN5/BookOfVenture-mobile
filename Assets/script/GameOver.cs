using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public Image imageToActivate;

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            imageToActivate.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);

            SceneManager.LoadScene("GameOver");
        }
    }
}
