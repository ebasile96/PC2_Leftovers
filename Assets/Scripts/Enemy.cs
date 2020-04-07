using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour, IEnemy
{
    public EnemyData Data;
    //public Animation Anim;
    public FieldOfView Fow;
    public EnemyController EnemyCtrl;
    public NavMeshAgent NavAgent;
    public HealthController HealthCtrl;
    int playerLayer = 10;
    int petLayer = 11;
    public Animator anim;

    void Start()
    {
        Setup();
    }

    public void Setup()
    {
        //Anim = GetComponent<Animation>();
        Fow = GetComponent<FieldOfView>();
        EnemyCtrl = GetComponent<EnemyController>();
        NavAgent = GetComponent<NavMeshAgent>();
        HealthCtrl = FindObjectOfType<HealthController>();
       // NavAgent.stoppingDistance = Data.StoppingDistance;
        NavAgent.speed = Data.speed;
    }
 
    public void Attack(GameObject _target)
    {
        HealthCtrl.Life -= Data.damage;
        Debug.Log("EnemyAttack");
        //attack method
    }

    public void FollowPlayer()
    {

        foreach (Transform target in Fow.visibleTargets)
        {
            if (target.gameObject.layer == playerLayer || target.gameObject.layer == petLayer)
            {
                NavAgent.destination = target.position;
                anim.SetTrigger("GoToRunning");
                Debug.Log("animazion funge");
            }
            else
            {
                anim.SetTrigger("GoToidle");
                Debug.Log("animazion funge");
            }

        }
    }


}
