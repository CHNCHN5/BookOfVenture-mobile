using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public GameObject DeactCan1;
    public GameObject DeactCan2;

    private void Srt()
    {
        StartCoroutine(Ply());
    }

    public void Strt()
    {
        Srt();
    }

    private IEnumerator Ply()
    {
        yield return new WaitForSeconds(3);
     
        DeactCan1.SetActive(false);
        DeactCan2.SetActive(false);

        SceneManager.LoadScene("SampleScene");      
    }

    public void NewGameDely()
    {
        StartCoroutine(OnNewGameDely());
    }

    public void OnNewGameClicked()
    {
        NewGameDely();
    }

    public IEnumerator OnNewGameDely()
    {
        yield return new WaitForSeconds(3);


        DataPersistenceManager.instance.NewGame();

        // Save the new game data
        DataPersistenceManager.instance.SaveGame();

        // Load the scene
        SceneManager.LoadScene("SampleScene");
    }

    public void OnNLoadGameClicked()
    {
        DataPersistenceManager.instance.LoadGame();
    }

    public void OnSaveGameClicked()
    {
        DataPersistenceManager.instance.SaveGame();
    }

    private void EnableGameObjectWithTag(string tag)
    {
        GameObject[] objectsToEnable = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }
}
