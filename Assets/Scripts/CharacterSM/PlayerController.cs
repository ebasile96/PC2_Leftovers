using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TellInput;

public class PlayerController : MonoBehaviour
{
    public PlayerBaseState currentState;
    public PetController pet;
    public float moveSpeed;
    public Animator animator;
    CharacterController characterController;
    private Vector3 lookDir;
    private Vector3 oldLookDir;
    public float turnSpeed;
    private Vector3 _velocity;
    [HideInInspector]
    public Vector3 movement;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
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
   
    public void Move()
    {
        movement = new Vector3(GameManager.instance.Inputmgr.horizontal, 0, GameManager.instance.Inputmgr.vertical) * moveSpeed * Time.deltaTime;
        lookDir = new Vector3(movement.x, 0f, movement.z);

        // determine method of rotation
        if (GameManager.instance.Inputmgr.horizontal != 0 || GameManager.instance.Inputmgr.vertical != 0)
        {

            // create a smooth direction to look at using Slerp()
            Vector3 smoothDir = Vector3.Slerp(transform.forward, lookDir, turnSpeed * Time.deltaTime);

            transform.rotation = Quaternion.LookRotation(smoothDir);

            // store the current smooth direction to use when the player is not providing input, providing consistency
            oldLookDir = smoothDir;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(oldLookDir);
        }

        // move the player using its CharacterController.Move method
        characterController.Move(movement);

        //per gravità
        _velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(_velocity * Time.deltaTime);
        if (_velocity.y != 0f)
            _velocity.y = 0;
    }

}
