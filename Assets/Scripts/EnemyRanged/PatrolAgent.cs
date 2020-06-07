using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using DG.Tweening;

public class PatrolAgent : MonoBehaviour
{
    public RangedStateBehaviour currentState;
    public int destPoint;
    public int actualDestPoint;
    public float attackTimer;
    public bool isAttack;
    public Transform[] points;
    public float maxTimerAttack;
    public GameObject projectile;
    public float speedProjectile;
    public float damagePhysic;
    public float rateoDamagePhysic;
    public EnemyData data;
    public NavMeshAgent agent;
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

        //settaggi valori per movimento enemy
        agent.speed = data.speed;
        agent.acceleration = data.acceleration;
        agent.angularSpeed = data.angularSpeed;
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
    public Rigidbody rb;
    public void Attack()
    {
        GameObject bullet = Instantiate(projectile, originShoot.position, Quaternion.LookRotation(originShoot.forward)) as GameObject;
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
        RaycastHit hit;
        Ray rayLine = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(rayLine, out hit, 1000))
        {
            lineR.SetPosition(0, transform.position);
            lineR.SetPosition(1, hit.point);
        }
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
    public void OnCollisionStay(Collision hit)
    {

        if (hit.gameObject.tag == "Player" && canTakeDamage == true)
        {
            pHealth.TakeDamage(data.damage);
            Instantiate(vfx.vfxHitTest, hit.transform);
            //SoundManager.PlaySound(SoundManager.Sound.femaleTakeDamage);

            StartCoroutine(damageTimer());
        }
    }
    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(data.rateoDamage);
        canTakeDamage = true;
    }

}
