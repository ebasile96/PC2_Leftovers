﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainNeutralState : ChainBaseState
{
    public ChainController chainController;
    public FieldOfView fow;
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
        fow.lineR.material = chainController.neutralMaterial;
        if (chainController.stressValue > 50)
        {
            chainController.ChangeState(lightState);
        }
    }
}