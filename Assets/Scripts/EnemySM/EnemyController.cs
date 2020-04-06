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
    }

    public void Update()
    {
        anim = GetComponent<Animator>();
        currentState.Tick();
        // provvisorio
        anim.SetTrigger("GoToRunning");
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        float targetCharacter = Vector3.Distance(transform.position, targetObjectCharacter.transform.position);
        float targetCompanion = Vector3.Distance(transform.position, targetObjectCompanion.transform.position);

        if(targetCharacter > targetCompanion) 
        {
            NavAgent.destination = targetObjectCharacter.transform.position;
            NavAgent.speed = Data.Speed;
        }
        else if (targetCharacter < targetCompanion)
        {
            NavAgent.destination = targetObjectCompanion.transform.position;
            NavAgent.speed = Data.Speed;
        }
    }


    private bool canTakeDamage = true;

    public void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.tag == "Player" && canTakeDamage == true)
        {
            pHealth.TakeDamage(Data.Damage);
            Instantiate(vfx.vfxHitTest, hit.transform);
            SoundManager.PlaySound(SoundManager.Sound.femaleTakeDamage);

            StartCoroutine(damageTimer());
        }
    }
    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(Data.rateoDamage);
        canTakeDamage = true;
    }
    /*public void Attack(GameObject _target)
    {
        HealthCtrl.Life -= Data.Damage;
        Debug.Log("EnemyAttack");
        //attack method
    }

   

    public void TakeDamagePlayer()
    {
        PlayerLifeController pHealth = hit.collider.GetComponent<PlayerLifeController>();
        pHealth.TakeDamage(1);
    }*/
}
