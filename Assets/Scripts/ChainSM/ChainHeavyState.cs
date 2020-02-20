using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainHeavyState : ChainBaseState
{
    public ChainController chainController;
    public FieldOfView fow;
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
        fow.lineR.material = chainController.heavyMaterial;
    }
}
