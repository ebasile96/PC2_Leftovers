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
    public Player player;
    public GameObject projectile;
    Transform petPosition;
    public float speedProjectile;

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
 
    }

    public void Update()
    {
        currentState.Tick();

        if (player.shootPet)
        {
            Shoot();
        }
    }

    
    public void Follow()
    {
        transform.LookAt(transform.forward);
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
        player = playerCtrl.gameObject;
        transform.LookAt(player.transform.position);
        
    }

    public void GoThere() { }

    public void Shoot()
    {
        GameObject temp;
        temp = Instantiate(projectile, transform.forward + new Vector3(petPosition.position.x, 0.5f, petPosition.position.z), Quaternion.identity);
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * speedProjectile);
    }
}
