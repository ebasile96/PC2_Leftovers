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

    public void RunControll(float _runPlayer, PlayerBaseState newState)
    {
        if(_runPlayer == 1)
        {
            newState.Enter();
            currentState = newState;
        }
    }

    public void NormalRunPlayer()
    {
        moveSpeed = normalMoveSpeed;
    }

    private GameObject gameObjectVfx;
    public void CreateVfxRun(Transform _transform, GameObject _object)
    {
       gameObjectVfx = Instantiate(_object, _transform);
    }

    public void DestroyVfxRun()
    {
        Destroy(gameObjectVfx);
    }

    public void SwapPG()
    {
        if (GameManager.instance.Inputmgr.swap)
        {
            //swap player
            Vector3 temp = transform.position;
            //Vector3 fixHigh = transform.position - new Vector3(0,0.5,0);
            characterController.enabled = false;
            transform.position = pet.transform.position - new Vector3(0, 1f, 0);
            Instantiate(GameManager.instance.Vfxmgr.vfxSwapCharacter, transform);
            characterController.enabled = true;
            //swap pet
            pet.characterControllerPet.enabled = false;
            pet.transform.position = temp - new Vector3(0, 2f, 0);
            Instantiate(GameManager.instance.Vfxmgr.vfxSwapPet, pet.transform);
            pet.characterControllerPet.enabled = true;
        }
    }
}
