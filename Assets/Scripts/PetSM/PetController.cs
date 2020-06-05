using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetController : MonoBehaviour
{
    public PetStateBase currentState;
    public Animator animator;
    public float moveSpeed;
    public float runSpeed;
    public float normalMoveSpeed;
    public CharacterController characterControllerPet;
    private Vector3 lookDir;
    private Vector3 oldLookDir;
    public float turnSpeed;
    public Vector3 _velocity;
    [HideInInspector]
    public Vector3 movement;
    public ChainController chainController;
    public PlayerController player;
    [HideInInspector]
    public bool isSwapPet;

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
        invMatPet.SetActive(false);
        player = FindObjectOfType<PlayerController>();
    }

    public void Update()
    {
        currentState.Tick();
    }

    public void MovePet(float _horizontalPet, float _verticalPet)
    {
        movement = new Vector3(_horizontalPet, 0, _verticalPet) * moveSpeed * Time.deltaTime;
        lookDir = new Vector3(movement.x, 0f, movement.z);

        if (_horizontalPet != 0 || _verticalPet != 0)
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

    public GameObject invMatPet;
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            chainController.ReformeChainCollision();
        }
    }

    public void SuperRunPet()
    {
        moveSpeed = runSpeed;
    }

    public void NormalRunPet()
    {
        moveSpeed = normalMoveSpeed;
    }

    public void RunControllPet(float _runPet, PetStateBase newState)
    {
        if(_runPet == 1)
        {
            newState.Enter();
            currentState = newState;
        }
    }
}
