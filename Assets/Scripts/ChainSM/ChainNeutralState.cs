using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainNeutralState : ChainBaseState
{
    public ChainController chainController;
    public ChainGraphic chainGr;
    public ChainBaseState lightState;
    public ChainBaseState mediumState;
    public ChainBaseState heavyState;

    public override void Enter()
    {
        
        //chainController = GetComponent<ChainController>();
        //fow = GetComponent<FieldOfView>();
        //fow.lineR.material = chainController.neutralMaterial;
    }

    public override void Tick()
    {
        chainGr.lineR.material = chainGr.neutralMaterial;
        if (chainController.currentStressValue > 50)
        {
            chainController.ChangeState(lightState);
        }
    }
}
