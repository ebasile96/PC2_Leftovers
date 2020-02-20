using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    public ChainBaseState currentState;
    public float stressValue;
    public Material lightMaterial;
    public Material mediumMaterial;
    public Material heavyMaterial;
    public Material neutralMaterial;

    public void ChangeState(ChainBaseState newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Tick();
    }


}
