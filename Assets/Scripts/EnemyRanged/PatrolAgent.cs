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
    public float attackTimer;
    public float maxTimerAttack;
    public GameObject projectile;
    public LineRenderer lineR;
    public Transform targetLine;
    public Animator anim;
    private VFXManager vfx;
    private PlayerLifeController pHealth;
    private PlayerController targetObjectCharacter;
    private PetController targetObjectCompanion;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = FindObjectOfType<Animator>();
        agent.autoBraking = false;
        pHealth = FindObjectOfType<PlayerLifeController>();
        vfx = FindObjectOfType<VFXManager>();
        targetObjectCharacter = FindObjectOfType<PlayerController>();
        targetObjectCompanion = FindObjectOfType<PetController>();
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
        GameObject bullet = Instantiate(projectile, originShoot.position, Quaternion.LookRotation(Vector3.forward)) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speedProjectile);
        isAttack = true;
    }


    public float targetCharacter;
    public float targetCompanion;
    public void LookTarget()
    {
         targetCharacter = Vector3.Distance(transform.position, targetObjectCharacter.transform.position);
         targetCompanion = Vector3.Distance(transform.position, targetObjectCompanion.transform.position);

        if (targetCharacter < targetCompanion)
        {
            agent.transform.LookAt(targetObjectCharacter.transform);
        }
        else if (targetCompanion < targetCharacter)
        {
            agent.transform.LookAt(targetObjectCompanion.transform);
        }
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

    private bool canTakeDamage = true;
    public float damage;
    public float rateoDamage;
    public void OnCollisionStay(Collision hit)
    {

        if (hit.gameObject.tag == "Player" && canTakeDamage == true)
        {
            pHealth.TakeDamage(damage);
            Instantiate(vfx.vfxHitTest, hit.transform);
            SoundManager.PlaySound(SoundManager.Sound.femaleTakeDamage);

            StartCoroutine(damageTimer());
        }
    }
    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(rateoDamage);
        canTakeDamage = true;
    }

}
