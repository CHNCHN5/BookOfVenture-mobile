using System.Collections;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    private Transform target;
    public float moveSpeed = 3.0f;
    public float stoppingDistance = 1.0f;

    private Coroutine moveCoroutine;
    private Animator anima;

    public GameObject Danger, Bg;
    public GameObject Warning;

    public float maxDistance = 10.0f;
    public float initialCapacity = 1.0f;
    public float capacityIncrement = 0.1f;

    private void Start()
    {
        anima = GetComponent<Animator>();
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            Warning.SetActive(true);

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    // Enemy can see the player and there are no obstructions
                    if (moveCoroutine == null)
                    {
                        moveCoroutine = StartCoroutine(MoveTowardsTarget(target.position));
                    }

                    anima.SetBool("isRun", true); // Player is visible, set animation to run
                    Danger.SetActive(true);
                    Warning.SetActive(false);

                    // Increase the capacity of Bg based on distance to target
                    float scaleFactor = distanceToTarget / maxDistance; // You can set maxDistance as per your requirement
                    float newCapacity = initialCapacity + (scaleFactor * capacityIncrement);
                    Bg.transform.localScale = new Vector3(newCapacity, newCapacity, newCapacity);
                }
                else
                {
                    anima.SetBool("isRun", false); // Player is visible but obstructed, set animation to idle
                    anima.SetBool("isWalk", true);
                }
            }
            else
            {
                anima.SetBool("isRun", false); // Player is not directly within FOV, set animation to idle
                anima.SetBool("isWalk", true);
            }
        }
        else
        {
            Warning.SetActive(false);
            Danger.SetActive(false);
            anima.SetBool("isRun", false); // Player is not visible, set animation to idle
            anima.SetBool("isWalk", false);
            target = null;
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
                moveCoroutine = null;
            }
        }
    }


    private IEnumerator MoveTowardsTarget(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            transform.LookAt(targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        moveCoroutine = null;
    }


    // Method to check if the player is visible to the enemy
    public bool IsPlayerVisible()
    {       
        return target != null;
    }
}
