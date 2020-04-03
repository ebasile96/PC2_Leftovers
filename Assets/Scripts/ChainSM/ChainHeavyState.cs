using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainHeavyState : ChainBaseState
{
    public ChainController chainController;
    public ChainGraphic chainGr;
    public ChainBaseState lightState;
    public ChainBaseState mediumState;
    public ChainBaseState neutralState;

    public override void Enter()
    {
        //chainController = GetComponent<ChainController>();
        //fow = GetComponent<FieldOfView>();
        //fow.lineR.material = chainController.heavyMaterial;
    }

    public override void Tick()
    {
        chainGr.lineR.material = chainGr.heavyMaterial;
        if(chainController.currentStressValue < 90)
        {
            chainController.ChangeState(mediumState);
        }
        else if(chainController.currentStressValue == 100)
        {
            //stato rottura completa
        }
    }
}
