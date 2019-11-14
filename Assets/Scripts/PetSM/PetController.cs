using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetController : MonoBehaviour
{
    public PetStateBase currentState;
    public FieldOfView fow;
    NavMeshAgent pet;
    int playerLayer = 10;

    public void ChangeState(PetStateBase newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    public void Start()
    {
        pet = GetComponent<NavMeshAgent>();
        fow = GetComponent<FieldOfView>();
        
 
    }

    public void Update()
    {
        currentState.Tick();
      
    }

    
    public void Follow()
    {
        
        foreach (Transform target in fow.visibleTargets)
        {
            if(target.gameObject.layer == playerLayer)
            { 
                pet.destination = target.position;
            }
            
        }
    }

    public void Stay(GameObject player)
    {
        ///animazione idle
        ///lookat verso il player
        
        transform.LookAt(player.transform.position);
        
    }

    public void GoThere() { }


}
