using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightState : ChainBaseState
{
    public ChainController chainController;
    public ChainGraphic chainGr;
    public ChainBaseState neutralState;
    public ChainBaseState mediumState;
    public ChainBaseState heavyState;
    public ChainBaseState brokenState;

    public override void Enter()
    {

    }

    public override void Tick()
    {

        chainGr.lineR.material = chainGr.lightMaterial;

        if (chainController.currentStressValue >= 75 && chainController.currentStressValue < 100)
        {
            chainController.ChangeState(mediumState);
        }
        else if (chainController.currentStressValue >= 100)
        {
        chainController.ChangeState(brokenState);
        }
        else if (chainController.currentStressValue < 50)
        {
            chainController.ChangeState(neutralState);
        }
    }
}
