﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainHeavyState : ChainBaseState
{
    public ChainController chainController;
    public ChainGraphic chainGr;
    public ChainBaseState lightState;
    public ChainBaseState mediumState;
    public ChainBaseState neutralState;
    public ChainBaseState brokenState;

    public override void Enter()
    {

    }

    public override void Tick()
    {
        chainGr.lineR.material = chainGr.heavyMaterial;
        if(chainController.currentStressValue < 90)
        {
            chainController.ChangeState(mediumState);
        }
        else if (chainController.currentStressValue >= 100)
        {
            chainController.ChangeState(brokenState);
        }
    }
}
