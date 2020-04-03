using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMediumState : ChainBaseState
{
    public ChainController chainController;
    public FieldOfView fow;
    public ChainBaseState neutralState;
    public ChainBaseState lightState;
    public ChainBaseState heavyState;

    public override void Enter()
    {
      
        //chainController = GetComponent<ChainController>();
        //fow = GetComponent<FieldOfView>();
        //fow.lineR.material = chainController.mediumMaterial;
    }

    public override void Tick()
    {
        fow.lineR.material = chainController.mediumMaterial;
        if (chainController.currentStressValue >= 90)
        {
            chainController.ChangeState(heavyState);
        }
        else if(chainController.currentStressValue < 75)
        {
            chainController.ChangeState(lightState);
        }
    }
}
