using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainBrokenState : ChainBaseState
{
    public ChainController chainController;
    public ChainGraphic chainGr;
    public ChainBaseState lightState;
    public ChainBaseState mediumState;
    public ChainBaseState heavyState;
    public ChainBaseState neutralState;

    public override void Enter()
    {
        chainGr.ChainGraphicBreaker();
        chainController.currentStressValue = chainController.reforgeStressValue;
    }

    public override void Tick()
    {
        chainController.ChainReformer();

        if (chainController.reforgeTimer <= 0 || chainController.isCollisionReforme == true)
        {
            chainController.ChangeState(neutralState);
        }
    }

    public override void Exit()
    {
        chainController.reforgeTimer = chainController.maxReforgeTimer;
        chainController.isCollisionReforme = false;
    }
}
