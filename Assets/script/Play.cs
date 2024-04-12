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

    // Update is called once per frame
    void Update()
    {
        
    }
}
