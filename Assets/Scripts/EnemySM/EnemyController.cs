using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public EnemyStateBase currentState;
    NavMeshAgent enemy;
    public EnemyData Data;
    //public Animation Anim;
    public FieldOfView fow;
    public EnemyController EnemyCtrl;
    public NavMeshAgent NavAgent;
    public HealthController HealthCtrl;
    int playerLayer = 10;
    int petLayer = 11;
    public Animator anim;


    public void ChangeState(EnemyStateBase newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    public void Start()
    {
        //enemy = GetComponent<NavMeshAgent>();
        EnemyCtrl = GetComponent<EnemyController>();
       // NavAgent = GetComponent<NavMeshAgent>();
        HealthCtrl = FindObjectOfType<HealthController>();
        //NavAgent.stoppingDistance = Data.StoppingDistance;
        //NavAgent.speed = Data.Speed;
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        anim = GetComponent<Animator>();
        currentState.Tick();
        //StartCoroutine(AttackMelee());
        // provvisorio
        anim.SetTrigger("GoToRunning");
        pHealth = FindObjectOfType<PlayerLifeController>();
    }

   

    public int rangeAttack;
    public RaycastHit hit;
    public bool isPlayer;
    public float rateoDamage;
    public float strength;
    public GameObject targetShake;
    public PlayerLifeController petLife;
    public PlayerLifeController pHealth;
    /*public IEnumerator AttackMelee()
    {
        Ray rayForward = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(rayForward, out hit, rangeAttack) && hit.collider.tag == "Player")
        {
            Debug.DrawRay(transform.position + new Vector3(0, 10f), transform.forward * hit.distance, Color.red);
            pHealth = hit.collider.GetComponent<PlayerLifeController>();
            petLife = hit.collider.GetComponent<PlayerLifeController>();
            if (pHealth.healthPlayer == 100 && hit.collider.tag == "Player")
            {
                pHealth.TakeDamage(20);
                petLife.TakeDamage(20);
                hit.transform.DOShakeScale(0.5f, strength);
                SoundManager.PlaySound(SoundManager.Sound.femaleTakeDamage);
            }
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 80 && hit.collider.tag == "Player")
            {
                pHealth.TakeDamage(20);
                petLife.TakeDamage(20);
                hit.transform.DOShakeScale(0.5f, strength);
                SoundManager.PlaySound(SoundManager.Sound.femaleTakeDamage);
            }
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 60 && hit.collider.tag == "Player")
            {
                pHealth.TakeDamage(20);
                petLife.TakeDamage(20);
                hit.transform.DOShakeScale(0.5f, strength);
                SoundManager.PlaySound(SoundManager.Sound.femaleTakeDamage);
            }
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 40 && hit.collider.tag == "Player")
            {
                pHealth.TakeDamage(20);
                petLife.TakeDamage(20);
                hit.transform.DOShakeScale(0.5f, strength);
                SoundManager.PlaySound(SoundManager.Sound.femaleTakeDamage);
            }
            yield return new WaitForSeconds(rateoDamage);
            if (pHealth.healthPlayer == 20 && hit.collider.tag == "Player")
            {
                pHealth.TakeDamage(20);
                petLife.TakeDamage(20);
                hit.transform.DOShakeScale(0.5f, strength);
                SoundManager.PlaySound(SoundManager.Sound.femaleTakeDamage);
            }
            yield return new WaitForSeconds(rateoDamage);
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }

    }*/

    /*public void FollowPlayer()
    {

        foreach (Transform target in fow.visibleTargets)
        {
            if (target.gameObject.layer == playerLayer || target.gameObject.layer == petLayer)
            {
                NavAgent.destination = target.position;

                Debug.Log("animazion funge");
            }
            else
            {
                Debug.Log("animazion funge");
            }

        }
    }*/


    private bool canTakeDamage = true;

    public void OnCollisionEnter(Collision hit)
    {

        //pHealth = hit.collider.GetComponent<PlayerLifeController>();
        //petLife = hit.collider.GetComponent<PlayerLifeController>();

        if (hit.gameObject.tag == "Player" && canTakeDamage == true)
        {
            //pHealth.TakeDamage(20);
            //petLife.TakeDamage(20);
            pHealth.TakeDamage(Data.Damage);
            hit.transform.DOShakeScale(0.5f, strength);
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
