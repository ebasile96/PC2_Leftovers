using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public PetStateBase currentState;
    public FieldOfView fow;
    Vector3 currentTransform;
    Vector3 targetTransform;
    public float moveSpeed = 2f;
    string playerLayer = "player";
    
    

    public void ChangeState(PetStateBase newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    public void Start()
    {
        
        fow = GetComponent<FieldOfView>();
        currentTransform = targetTransform + new Vector3(-2.5f, 0, 0);
  
    }

    public void Update()
    {
        currentState.Tick();
        currentTransform = transform.position;
    }

    
    public void Follow()
    {
        

        foreach (Transform target in fow.visibleTargets)
        {

            if (!playerLayer.Equals(LayerMask.GetMask(target.name)))
            {
                targetTransform = target.position;
                Debug.Log(target.name);
            }
        }

        float approach = moveSpeed * Time.deltaTime;
        transform.LookAt(targetTransform);
        transform.position = Vector3.MoveTowards(currentTransform,( targetTransform + new Vector3(-2.5f, 0, 0)), approach) * moveSpeed;
       



    }

    public void Stay() { }

    public void GoThere() { }


}
