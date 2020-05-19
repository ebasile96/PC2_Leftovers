using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChainBrokenState : ChainBaseState
{
    public ChainController chainController;
    public ChainGraphic chainGr;
    public ChainBaseState lightState;
    public ChainBaseState mediumState;
    public ChainBaseState heavyState;
    public ChainBaseState neutralState;
    Action ChainBrokenCallback;
    Action ChainReforgedCallback;
    public override void Enter()
    {
        ChainBrokenCallback();
        chainGr.ChainGraphicBreaker();
        chainController.currentStressValue = chainController.reforgeStressValue;
    }

    public override void Tick()
    {
        chainController.ChainReformer();

        if (chainController.reforgeTimer <= 0 || chainController.isCollisionReforme == true)
        {
            ChainReforgedCallback();
            chainController.ChangeState(neutralState);
        }
    }

    public override void Exit()
    {
        chainController.reforgeTimer = chainController.maxReforgeTimer;
        chainController.isCollisionReforme = false;
    }

    public void ChainBrokenCall(Action _chainCall)
    {
        ChainBrokenCallback = _chainCall;
    }

    public void ChainReforgedCall(Action _chainReforge)
    {
        ChainReforgedCallback = _chainReforge;
    }
}
