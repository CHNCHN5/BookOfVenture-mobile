using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class RoamingEn : MonoBehaviour, IDataPersistence
{
    public NavMeshAgent agent;
    public float range; //radius of sphere
    public float delayBetweenMoves = 0f; // Delay between finding new random points

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    private Animator anim;

    public void LoadData(GameData data)
    {
        // Load agent position from GameData
        this.transform.position = data.agentPosition;
    }

    public void SaveData(ref GameData data)
    {
        // Save agent position to GameData
        data.agentPosition = this.transform.position;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        // Start coroutine for roaming
        StartCoroutine(Roam());
    }

    IEnumerator Roam()
    {
        while (true)
        {
            if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
                {
                    anim.SetBool("isWalk", false);
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                }
            }
            yield return new WaitForSeconds(delayBetweenMoves);
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        anim.SetBool("isWalk", true);
        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
