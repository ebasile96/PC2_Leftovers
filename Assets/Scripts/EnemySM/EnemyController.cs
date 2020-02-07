using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    public EnemyStateBase currentState;
    public FieldOfView fow;
    NavMeshAgent enemy;
   

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

   

    public int rangeAttack;
    public RaycastHit hit;
    public bool isPlayer;
    public float rateoDamage;
    public float strength;
    public GameObject targetShake;
    public IEnumerator AttackMelee()
    {
        Ray rayForward = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(rayForward, out hit, rangeAttack) && hit.collider.tag == "Player")
        {
            Debug.DrawRay(transform.position + new Vector3(0, 10f), transform.forward * hit.distance, Color.red);
            PlayerLifeController pHealth = hit.collider.GetComponent<PlayerLifeController>();
            if (pHealth.healthPlayer == 100 && hit.collider.tag == "Player")
            {
                pHealth.TakeDamage(20);
                hit.transform.DOShakeScale(0.5f, strength);
            }
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 80 && hit.collider.tag == "Player")
            {
                pHealth.TakeDamage(20);
                hit.transform.DOShakeScale(0.5f, strength);
            }
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 60 && hit.collider.tag == "Player")
            {
                pHealth.TakeDamage(20);
                hit.transform.DOShakeScale(0.5f, strength);
            }
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 40 && hit.collider.tag == "Player")
            {
                pHealth.TakeDamage(20);
                hit.transform.DOShakeScale(0.5f, strength);
            }
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 20 && hit.collider.tag == "Player")
            {
                pHealth.TakeDamage(20);
                hit.transform.DOShakeScale(0.5f, strength);
            }
            yield return new WaitForSeconds(rateoDamage);
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }

    }

    public void TakeDamagePlayer()
    {
        PlayerLifeController pHealth = hit.collider.GetComponent<PlayerLifeController>();
        pHealth.TakeDamage(1);
    }
}
