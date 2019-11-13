using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    public PlayerBaseState currentState;
    public Agent player;
    public float speed;
    public float speedRotation;
    internal Vector3 position;
    internal float targetForward;
    internal Quaternion rotation;
    public float lenghtDash;
    public float distDash;

    public int ObDash;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
        ObDash = 0;
    }

  
    

    public void ChangeState(PlayerBaseState newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }
    // Update is called once per frame
    void Update()

    {
        currentState.Tick();

    }

    Vector3 moveDirection;
    public void Move()
    {
       
        CharacterController moveController = GetComponent<CharacterController>();
        moveDirection = new Vector3(0, 0, player.forward);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        moveController.Move(moveDirection * Time.deltaTime);
    }

    public void Rotate(float rotate)
    {
        //this.transform.rotation = Quaternion.Euler(Vector3.up * rotate * speedRotation * Time.deltaTime) * rotation;
        this.transform.Rotate(0, player.rotate * speedRotation, 0);
    }

    public void UpdatePositionAndRotation()
    {
        this.transform.SetPositionAndRotation(this.transform.position , this.transform.rotation);
    }

    public void DashForward()
    {
        //this.transform.DOMove(transform.forward, speedDash);
        this.transform.position += this.transform.forward * lenghtDash;
    }
   

    public int rangeAttack;
    public RaycastHit hit;

    public void AttackMelee()
    {
        Ray rayForward = new Ray(transform.position, transform.forward);
       

        if (Physics.Raycast(rayForward, out hit, rangeAttack) && hit.collider.tag == "Enemy")
        {
            Debug.DrawRay(transform.position + new Vector3(0, 10f), transform.forward * hit.distance, Color.red);
            EnemyHealth eHealth = hit.collider.GetComponent<EnemyHealth>();
            eHealth.TakeDamage(1);
            //testEnemy.transform.DOShakePosition(2f, strength);
            Debug.Log("prende raycast");
        }
        
    }

    public int rangeDash;
    public void DashObstacles()
    {
        Ray rayObstacle = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(rayObstacle, out hit, rangeDash) && hit.collider.tag == "Obstacle")
        {
            ObDash = 1;
            Debug.DrawRay(transform.position + new Vector3(0, 10f), transform.forward * hit.distance, Color.red);
            //testEnemy.transform.DOShakePosition(2f, strength);
            Debug.Log("prende raycast");
        }
        else
        {
            ObDash = 0;
        }

    }

}
