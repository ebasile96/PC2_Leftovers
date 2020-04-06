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
    public ChainBaseState brokenState;

    public override void Enter()
    {
        chainGr.ChainGraphicReforme();
    }

    public override void Tick()
    {
        chainGr.lineR.material = chainGr.neutralMaterial;
        if (chainController.currentStressValue > 50 && chainController.currentStressValue < 100)
        {
            chainController.ChangeState(lightState);
        }
        else if(chainController.currentStressValue >= 100)
        {
        chainController.ChangeState(brokenState);
        }
    }
}
