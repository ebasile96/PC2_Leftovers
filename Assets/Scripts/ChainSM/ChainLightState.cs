using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightState : ChainBaseState
{
    public ChainController chainController;
    public FieldOfView fow;
    public ChainBaseState neutralState;
    public ChainBaseState mediumState;
    public ChainBaseState heavyState;

    public override void Enter()
    {
       
        //chainController = GetComponent<ChainController>();
        //fow = GetComponent<FieldOfView>();
    }

    public override void Tick()
    {
        Debug.Log("valore" + chainController.currentStressValue);
        fow.lineR.material = chainController.lightMaterial;
        if (chainController.currentStressValue >= 75)
        {
            chainController.ChangeState(mediumState);
        }
        else if(chainController.currentStressValue < 50)
        {
            chainController.ChangeState(neutralState);

        }

    }
}
