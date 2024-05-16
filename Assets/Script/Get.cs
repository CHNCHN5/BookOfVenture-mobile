using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get : MonoBehaviour
{
    public GameObject ActivateG;
    public GameObject DeactivateG;
    public GameObject ActNxt1;
    public GameObject Nxtlvl1;
    public GameObject DeactGet1;

    public GameObject ActivateR;
    public GameObject DeactivateR;
    public GameObject ActNxt2;
    public GameObject Nxtlvl2;
    public GameObject DeactGet2;

    public GameObject ActivateO;
    public GameObject DeactivateO;

    public GameObject ActMap;
    public GameObject ActGem1;

    public GameObject ActTag1;
    public GameObject DeactGem1;

    public GameObject ActTag2;
    public GameObject DeactGem2;
    public GameObject Set1;

    public GameObject ActTag3;
    public GameObject DeactGem3;
    public GameObject Set2;

    public GameObject LstEff1;
    public GameObject LstEff2;

    private void Lst()
    {
        StartCoroutine(ActivationLst());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Green"))
        {
            DeactGet1.SetActive(false);
            DeactivateG.SetActive(false);
            ActivateG.SetActive(true);
            ActNxt1.SetActive(true);
            Nxtlvl1.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Red"))
        {
            DeactGet2.SetActive(false);
            DeactivateR.SetActive(false);
            ActivateR.SetActive(true);
            ActNxt2.SetActive(true);
            Nxtlvl2.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Orange"))
        {
            DeactivateO.SetActive(false);
            ActivateO.SetActive(true);
            ActMap.SetActive(true);
            ActGem1.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Tag1"))
        {
            ActTag1.SetActive(true);
            Set1.SetActive(true);
            DeactGem1.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Tag2"))
        {
            ActTag2.SetActive(true);
            Set2.SetActive(true);
            DeactGem2.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Tag3"))
        {
            ActTag3.SetActive(true);
            DeactGem3.SetActive(false);
            Lst();
        }
    }
    private IEnumerator ActivationLst()
    {
        yield return new WaitForSeconds(1);

        LstEff1.SetActive(true);

        yield return new WaitForSeconds(1);

        LstEff2.SetActive(true);
    }
}
