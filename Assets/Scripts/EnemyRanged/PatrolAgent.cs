using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using DG.Tweening;

public class PatrolAgent : MonoBehaviour
{
    public RangedStateBehaviour currentState;
    public Transform[] points;
    public int destPoint = 0;
    public int actualDestPoint;
    public NavMeshAgent agent;
    public bool isAttack;
    public Transform target;
    public float attackTimer;
    public float maxTimerAttack;
    public GameObject projectile;
    public LineRenderer lineR;
    public Transform targetLine;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
    }


    public void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.destination = points[destPoint].position;
            destPoint = (destPoint + 1) % points.Length;
        }
    }


    void Update()
    {
        currentState.Tick();

        if(destPoint == 5)
        {
            actualDestPoint = 0;
        }
   
    }

    public Transform originShoot;
    public float speedProjectile;
    public Rigidbody rb;
    public void Attack()
    {
        agent.transform.LookAt(target);
        Instantiate(projectile, originShoot.position, Quaternion.identity);
        projectile.transform.DOMove(Vector3.forward, 2);
        isAttack = true;
    }

    public void SetDirectionOfAttack()
    {
        lineR.SetPosition(0, transform.position);
        lineR.SetPosition(1, this.transform.position + this.transform.forward * 1000000);
    }

    public void ActiveLineRender()
    {
        lineR.enabled = true;
    }

    public void DisactiveLineRender()
    {
        lineR.enabled = false;
    }

    public void ChangeState(RangedStateBehaviour newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

}
