using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TellInput;

public class PlayerController : MonoBehaviour
{
    public PlayerBaseState currentState;
    public PetController pet;
    public float speed;
    public float speedRotation;
    internal Vector3 position;
    internal float targetForward;
    internal Quaternion rotation;
    public Animator animator;
   
    private void Awake()
    {
        animator = GetComponent<Animator>();
        pet = FindObjectOfType<PetController>();
    }

    void Update()
    {
        currentState.Tick();
    }
  

    public void ChangeState(PlayerBaseState newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }
   
    public Vector3 moveDirection;
    Vector3 _velocity;
    Transform rotateDirection;
    public void Move()
    {
       //per muovere
        CharacterController moveController = GetComponent<CharacterController>();
        moveDirection = new Vector3(GameManager.instance.Inputmgr.horizontal, 0, GameManager.instance.Inputmgr.vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        moveController.Move(moveDirection * Time.deltaTime);

        //per gravità
        _velocity.y += Physics.gravity.y * Time.deltaTime;
        moveController.Move(_velocity * Time.deltaTime);

        
        

    }

    public float _rotationSpeed;
    public void RotationPlayer()
    {
      
    }

   
}
