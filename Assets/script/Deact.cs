using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deact : MonoBehaviour
{
    public GameObject DecEff;

    private void Cnt()
    {
        StartCoroutine(Act());
    }

    // Start is called before the first frame update
    void Start()
    {
        Cnt();
    }

    private IEnumerator Act()
    {
        yield return new WaitForSeconds(2);

        DecEff.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
