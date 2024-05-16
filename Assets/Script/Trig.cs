using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{
    public GameObject Eff1;
    public GameObject Eff2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Eff1.SetActive(true);
            Ani();
        }
    }

    private void Ani()
    {
        StartCoroutine(ActivationAni());
    }

    private IEnumerator ActivationAni()
    {
        yield return new WaitForSeconds(1);

        Eff2.SetActive(true);

        yield return new WaitForSeconds(2);

        Eff1.SetActive(false);
    }
}
