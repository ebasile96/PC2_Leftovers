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
    }

    public override void Tick()
    {
        if (chainController.currentStressValue != 100)
        {
            chainController.ChangeState(neutralState);
        }
    }
}
