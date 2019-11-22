﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    public PlayerBaseState currentState;
    public Player player;
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
        player = GetComponent<Player>();
        pet = FindObjectOfType<PetController>();
        ObDash = 0;
        isShieldEnemy = true;
    }

    void Update()
    {
        currentState.Tick();
        DashObstacles();

        if(player.attackMelee)
        {
            Action();
            isCrystal = true;
        }

        if (player.dash)
        {
            DashForward();
        }

        if (player.attackMelee && isShieldEnemy == false)
        {
            AttackMelee();
        }

        if (player.stayHere)
        {
            PetStay stay = FindObjectOfType<PetStay>();
            pet.currentState = stay;
            
        }

        if (player.follow)
        {
            PetFollowState follow = FindObjectOfType<PetFollowState>();
            pet.currentState = follow;
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
        moveDirection = new Vector3(0, 0, player.forward);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        moveController.Move(moveDirection * Time.deltaTime);
        
    }

    public void Rotate()
    {
        
        transform.Rotate(0, player.rotate * speedRotation, 0);
    }

    public void UpdatePositionAndRotation()
    {
        transform.SetPositionAndRotation(transform.position , transform.rotation);
    }

    public void DashForward()
    {
        
        transform.position += transform.forward * lenghtDash;
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
            //hit.transform.DOShakePosition(2f, strength);
            Debug.Log("prende raycast");
        }
        
    }

    public void Action()
    {
        Ray rayFor = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(rayFor, out hit, rangeAttack) && hit.collider.tag == "Crystal")
        {

            Debug.Log("prende raycast cristallo");
        }
        else if (Physics.Raycast(rayFor, out hit, rangeAttack) && hit.collider.tag == "SecondCrystal")
        {
            Debug.Log("prende raycast secondo cristallo");
            isSecondCrystal = true;
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
