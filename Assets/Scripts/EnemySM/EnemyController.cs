using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour, IEnemy
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
        enemy = GetComponent<NavMeshAgent>();
        fow = GetComponent<FieldOfView>();
        EnemyCtrl = GetComponent<EnemyController>();
        NavAgent = GetComponent<NavMeshAgent>();
        HealthCtrl = FindObjectOfType<HealthController>();
        //NavAgent.stoppingDistance = Data.StoppingDistance;
        //NavAgent.speed = Data.Speed;

    }

    public void Update()
    {
        currentState.Tick();
        StartCoroutine(AttackMelee());
        //provvisorio
        if (pHealth.healthPlayer == 0)
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("caricoScene");
        }
    }

   

    public int rangeAttack;
    public RaycastHit hit;
    public bool isPlayer;
    public float rateoDamage;
    public float strength;
    public GameObject targetShake;
    public PlayerLifeController petLife;
    public PlayerLifeController pHealth;
    public IEnumerator AttackMelee()
    {
        Ray rayForward = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(rayForward, out hit, rangeAttack) && hit.collider.tag == "Player")
        {
            Debug.DrawRay(transform.position + new Vector3(0, 10f), transform.forward * hit.distance, Color.red);
            //PlayerLifeController pHealth = hit.collider.GetComponent<PlayerLifeController>();
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

    }

    public void FollowPlayer()
    {

        foreach (Transform target in fow.visibleTargets)
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

    public void Attack(GameObject _target)
    {
        HealthCtrl.Life -= Data.Damage;
        Debug.Log("EnemyAttack");
        //attack method
    }

    public void TakeDamagePlayer()
    {
        PlayerLifeController pHealth = hit.collider.GetComponent<PlayerLifeController>();
        pHealth.TakeDamage(1);
    }
}
