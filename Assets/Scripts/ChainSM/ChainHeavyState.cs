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
    public ChainBaseState brokenState;

    public override void Enter()
    {

    }

    public override void Tick()
    {
        //chainGr.lineR.material = chainGr.heavyMaterial;

        //controllo lunghezza catena
        if(chainGr.dstToTarget <= (chainGr.maxLenghtChain * 75) / 100)
        {
            chainController.ChangeState(mediumState);
        }
        else if (chainGr.dstToTarget >= chainGr.maxLenghtChain)
        {
            chainController.ChangeState(brokenState);
        }

        //controllo stress
        //if (chainController.currentStressValue >= 100)
        // {
        //chainController.ChangeState(brokenState);
        //}

        chainController.ChainObstacle(brokenState);
    }
}
