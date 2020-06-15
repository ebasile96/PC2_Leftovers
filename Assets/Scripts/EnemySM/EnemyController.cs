using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public EnemyStateBase currentState;
    public EnemyData Data;
    private NavMeshAgent NavAgent;
    private Animator anim;
    private PlayerLifeController pHealth;
    private PlayerController targetObjectCharacter;
    private PetController targetObjectCompanion;
    private VFXManager vfx;

    public void ChangeState(EnemyStateBase newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    public void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        //provvisorio
        pHealth = FindObjectOfType<PlayerLifeController>();
        targetObjectCharacter = FindObjectOfType<PlayerController>();
        targetObjectCompanion = FindObjectOfType<PetController>();
        vfx = FindObjectOfType<VFXManager>();

        //settaggi valori per movimento enemy
        NavAgent.speed = Data.speed;
        NavAgent.acceleration = Data.acceleration;
        NavAgent.angularSpeed = Data.angularSpeed;
    }

    public void Update()
    {
        anim = GetComponent<Animator>();
        currentState.Tick();
        // provvisorio
        if (canTakeDamage == true)
        {
            anim.SetTrigger("GoToRunning");
        }
        FollowPlayer();
    }

    public float targetCharacter;
    public float targetCompanion;
    public void FollowPlayer()
    {
         targetCharacter = Vector3.Distance(transform.position, targetObjectCharacter.transform.position);
         targetCompanion = Vector3.Distance(transform.position, targetObjectCompanion.transform.position);


        if (targetCharacter < targetCompanion) 
        {
            NavAgent.destination = targetObjectCharacter.transform.position;
            //NavAgent.speed = Data.speed;
            //NavAgent.acceleration = Data.acceleration;
            //NavAgent.angularSpeed = Data.angularSpeed;
        }
        else if (targetCompanion < targetCharacter)
        {
            NavAgent.destination = targetObjectCompanion.transform.position;
            //NavAgent.speed = Data.speed;
            //NavAgent.acceleration = Data.acceleration;
            //NavAgent.angularSpeed = Data.angularSpeed;
        }
    }


    private bool canTakeDamage = true;

    public void OnCollisionStay(Collision hit)
    {

        if (hit.gameObject.tag == "Player")
        {
            NavAgent.speed = 0;

            if (canTakeDamage == true) {
                anim.SetTrigger("GoToAttackCross");
                if (targetObjectCharacter.invulnerabilityCounter <= 0)
                {
                    pHealth.TakeDamage(Data.damage);
                    targetObjectCharacter.invulnerabilityCounter = targetObjectCharacter.invulnerabilityTimer;
                }
                Instantiate(vfx.vfxHitTest, hit.transform);
                //SoundManager.PlaySound(SoundManager.Sound.femaleTakeDamage);

                StartCoroutine(damageTimer());
            }
        }
    }

    public void OnCollisionExit(Collision hit)
    {
        NavAgent.speed = Data.speed;
    }


    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(Data.rateoDamage);
        canTakeDamage = true;
    }

   
}
