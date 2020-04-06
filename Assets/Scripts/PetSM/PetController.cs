using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetController : MonoBehaviour
{
    public PetStateBase currentState;
    public Animator animator;
    public float moveSpeed;
    CharacterController characterControllerPet;
    private Vector3 lookDir;
    private Vector3 oldLookDir;
    public float turnSpeed;
    public Vector3 _velocity;
    [HideInInspector]
    public Vector3 movement;
    public ChainController chainController;

    public void ChangeState(PetStateBase newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    public void Start()
    {
        characterControllerPet = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        currentState.Tick();
    }

    public void MovePet()
    {
        movement = new Vector3(GameManager.instance.Inputmgr.horizontalPet, 0, GameManager.instance.Inputmgr.verticalPet) * moveSpeed * Time.deltaTime;
        lookDir = new Vector3(movement.x, 0f, movement.z);

        if (GameManager.instance.Inputmgr.horizontalPet != 0 || GameManager.instance.Inputmgr.verticalPet != 0)
        {

            Vector3 smoothDir = Vector3.Slerp(transform.forward, lookDir, turnSpeed * Time.deltaTime);

            transform.rotation = Quaternion.LookRotation(smoothDir);

            oldLookDir = smoothDir;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(oldLookDir);
        }

        characterControllerPet.Move(movement);

        //per gravità
        _velocity.y += Physics.gravity.y * Time.deltaTime;
        characterControllerPet.Move(_velocity * Time.deltaTime);
        if (_velocity.y != 0f)
            _velocity.y = 0;
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            chainController.ReformeChainCollision();
        }
    }
}
