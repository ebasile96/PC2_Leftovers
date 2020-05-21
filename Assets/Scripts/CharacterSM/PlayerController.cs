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
    public float runSpeed;
    public float normalMoveSpeed;
    public Color runAura;
    public Color normalAura;
    public Animator animator;
    public ParticleSystem.MainModule aura;
    CharacterController characterController;
    private Vector3 lookDir;
    private Vector3 oldLookDir;
    public float turnSpeed;
    private Vector3 _velocity;
    [HideInInspector]
    public Vector3 movement;
    public bool isMoving;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        pet = FindObjectOfType<PetController>();
        invMat.SetActive(false);
    }

    void Update()
    {
        currentState.Tick();
        InvulnerabilityTimer();
        fixInvTimer();
    }
  

    public void ChangeState(PlayerBaseState newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }
   
    public void Move(float _horizontal, float _vertical)
    {
        movement = new Vector3(_horizontal, 0, _vertical) * moveSpeed * Time.deltaTime;
        lookDir = new Vector3(movement.x, 0f, movement.z);

        if (_horizontal != 0 || _vertical != 0)
        {

            Vector3 smoothDir = Vector3.Slerp(transform.forward, lookDir, turnSpeed * Time.deltaTime);

            transform.rotation = Quaternion.LookRotation(smoothDir);

            oldLookDir = smoothDir;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(oldLookDir);
        }

        characterController.Move(movement);

        //per gravità
        _velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(_velocity * Time.deltaTime);
        if (_velocity.y != 0f)
            _velocity.y = 0;
    }

    public bool isInvulnerability;
    public float invulnerabilityTimer;
    public float invulnerabilityCounter;
    public GameObject invMat;

    public void InvulnerabilityTimer()
    {
        if(invulnerabilityCounter > 0)
        {
            invulnerabilityCounter -= Time.deltaTime;
            invMat.SetActive(true);
            pet.invMatPet.SetActive(true);
        }
        else if(invulnerabilityCounter <= 0)
        {
            invMat.SetActive(false);
            pet.invMatPet.SetActive(false);
        }
    }

    private void fixInvTimer()
    {
        if (invulnerabilityCounter < 0)
        {
            invulnerabilityCounter = 0;
        }
    }

    public void SuperRunPlayer()
    {
        moveSpeed = runSpeed;
    }

    public void NormalRunPlayer()
    {
        moveSpeed = normalMoveSpeed;
    }

    public void SetColorRunAura()
    {
        aura = GetComponentInChildren<ParticleSystem>().main;
        aura.startColor = runAura;
    }

    public void SetColorNormalAura()
    {
        aura = GetComponentInChildren<ParticleSystem>().main;
        aura.startColor = normalAura;
    }

    [HideInInspector]
    public bool isSwapPlayer;
    public void SwapInput()
    {
        if(GameManager.instance.Inputmgr.swap && isSwapPlayer == false)
        {
            isSwapPlayer = true;
        }
        else if (GameManager.instance.Inputmgr.swap && isSwapPlayer == true)
        {
            isSwapPlayer = false;
        }
    }
}
