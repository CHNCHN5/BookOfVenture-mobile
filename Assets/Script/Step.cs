using System.Collections;
using UnityEngine;

public class ActivateAnimatorOnCollision : MonoBehaviour
{
    public Animator animator;
    public GameObject objectToDestroy;
    public GameObject effectActivate;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Open")) // Change "Player" to the tag of the object you want to collide with
        {
            animator.enabled = true;
            effectActivate.SetActive(true);
            Destroy(objectToDestroy);
            dely();
        }
    }
    private void dely()
    {
        StartCoroutine(Activation());
    }

    private IEnumerator Activation()
    {
        yield return new WaitForSeconds(3);

        effectActivate.SetActive(false);
    }
}
