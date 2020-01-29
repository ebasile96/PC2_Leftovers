using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetController : MonoBehaviour
{
    public PetStateBase currentState;
    public FieldOfView fow;
    public PlayerController playerCtrl;
    NavMeshAgent pet;
    int playerLayer = 10;
    int enemyLayer = 8;
    public Player player;
    public GameObject projectile;
    Transform petPosition;
    public float speedProjectile;
    public Animator animator;

    public void ChangeState(PetStateBase newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    public void Start()
    {
        petPosition = GetComponent<Transform>();
        player = FindObjectOfType<Player>();
        pet = GetComponent<NavMeshAgent>();
        fow = GetComponent<FieldOfView>();
        playerCtrl = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        currentState.Tick();

     
    }

    public float speed;
    Vector3 _velocity;
    public Vector3 moveDirection;
    public void MovePet()
    {
            CharacterController moveController = GetComponent<CharacterController>();
            moveDirection = new Vector3(GameManager.instance.Inputmgr.horizontalPet, 0, GameManager.instance.Inputmgr.verticalPet);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            moveController.Move(moveDirection * Time.deltaTime);
            moveDirection = Vector3.up;

        

        //per gravità
        _velocity.y += Physics.gravity.y * Time.deltaTime;
        moveController.Move(_velocity * Time.deltaTime);
    }

    public float _rotationSpeed;
    public void RotationPet()
    {
        Vector3 rotation = new Vector3(0, GameManager.instance.Inputmgr.horizontalPet * _rotationSpeed * Time.deltaTime, 0);
        this.transform.Rotate(rotation);
    }

    public void GoThere() { }

    Transform enemyTarget;
  
    
}
