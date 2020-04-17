using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class PatrolAgent : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public bool isActive;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        if (isActive == true)
        {
            agent.destination = points[destPoint].position;
            destPoint = (destPoint + 1) % points.Length;
        }
    }


    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
