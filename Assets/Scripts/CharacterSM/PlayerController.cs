using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    public PlayerBaseState currentState;
    public PetController pet;
    public float speed;
    public float speedRotation;
    internal Vector3 position;
    internal float targetForward;
    internal Quaternion rotation;
    public float lenghtDash;
    public float distDash;
    public bool isShieldEnemy;
    public bool isCrystal;
    public bool isSecondCrystal;
    public int ObDash;

    private void Awake()
    {
       
        pet = FindObjectOfType<PetController>();
        ObDash = 0;
        isShieldEnemy = true;
        shieldEnemy1.SetActive(true);
        shieldEnemy2.SetActive(true);
    }

    public GameObject shieldEnemy1;
    public GameObject shieldEnemy2;
    void Update()
    {
        currentState.Tick();
        DashObstacles();
        if (GameManager.instance.Inputmgr.dash)
        {
            DashForward();
        }

    }
  

    public void ChangeState(PlayerBaseState newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }
   
    Vector3 moveDirection;
    public void Move()
    {
       
        CharacterController moveController = GetComponent<CharacterController>();
        moveDirection = new Vector3(GameManager.instance.Inputmgr.horizontal, 0, GameManager.instance.Inputmgr.vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        moveController.Move(moveDirection * Time.deltaTime);
        moveDirection = Vector3.up;      
    }

    public void DashForward()
    {
        
        transform.position += transform.forward * lenghtDash;
    }
   

    public int rangeAttack;
    public RaycastHit hit;
    public float strength;

    public int rangeDash;
    public void DashObstacles()
    {
        Ray rayObstacle = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(rayObstacle, out hit, rangeDash) && hit.collider.tag == "Obstacle")
        {
            ObDash = 1;
            Debug.DrawRay(transform.position + new Vector3(0, 10f), transform.forward * hit.distance, Color.red);
            
            Debug.Log("prende raycast");
        }
        else
        {
            ObDash = 0;
        }

    }

}
