using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyStateBase currentState;
    NavMeshAgent agentEnemy;

    // Start is called before the first frame update
    void Start()
    {
        agentEnemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Tick();
    }

    public void ChangeState(EnemyStateBase newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    public void MovementEnemy()
    {
        
    }

   
    public int rangeAttack;
    public RaycastHit hit;

    //basic attack enemy
    public void AttackMelee()
    {
        Ray rayForward = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(rayForward, out hit, rangeAttack) && hit.collider.tag == "Player")
        {
            PlayerLifeController pHealth = hit.collider.GetComponent<PlayerLifeController>();
            pHealth.TakeDamage(1);
        }

    }
}

