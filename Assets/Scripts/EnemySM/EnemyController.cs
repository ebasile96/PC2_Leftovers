using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyStateBase currentState;
    public FieldOfView fow;
    NavMeshAgent enemy;
    int playerLayer = 10;

    public void ChangeState(EnemyStateBase newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    public void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        fow = GetComponent<FieldOfView>();


    }

    public void Update()
    {
        currentState.Tick();
        StartCoroutine(AttackMelee());
    }

    public void FollowPlayer()
    {

        foreach (Transform target in fow.visibleTargets)
        {
            if (target.gameObject.layer == playerLayer)
            {
                enemy.destination = target.position;
            }

        }
    }

    public int rangeAttack;
    public RaycastHit hit;
    public bool isPlayer;
    public float rateoDamage;
    public IEnumerator AttackMelee()
    {
        Ray rayForward = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(rayForward, out hit, rangeAttack) && hit.collider.tag == "Player")
        {
            Debug.DrawRay(transform.position + new Vector3(0, 10f), transform.forward * hit.distance, Color.red);
            PlayerLifeController pHealth = hit.collider.GetComponent<PlayerLifeController>();
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 3)
            {
                pHealth.TakeDamage(1);
                
            }
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 2)
            {
                pHealth.TakeDamage(1);

            }
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 1)
            {
                pHealth.TakeDamage(1);

            }
            yield return new WaitForSeconds(rateoDamage);
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }

    }

    /*public void TakeDamagePlayer()
    {
        PlayerLifeController pHealth = hit.collider.GetComponent<PlayerLifeController>();
        pHealth.TakeDamage(1);
    }*/
}
