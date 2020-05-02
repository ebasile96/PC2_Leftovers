using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMediumState : ChainBaseState
{
    public ChainController chainController;
    public ChainGraphic chainGr;
    public ChainBaseState neutralState;
    public ChainBaseState lightState;
    public ChainBaseState heavyState;
    public ChainBaseState brokenState;

    public override void Enter()
    {

    }

    public override void Tick()
    {
        //chainGr.lineR.material = chainGr.mediumMaterial;
        /*if (chainController.currentStressValue >= 90 && chainController.currentStressValue < 100)
        {
            chainController.ChangeState(heavyState);
        }
        else if (chainController.currentStressValue >= 100)
        {
        chainController.ChangeState(brokenState);
        }
        else if (chainController.currentStressValue < 75)
        {
            chainController.ChangeState(lightState);
        }*/

        //controllo lunghezza catena
        if (chainGr.dstToTarget >= (chainGr.maxLenghtChain * 90) / 100)
        {
            chainController.ChangeState(heavyState);
        }
        else if (chainGr.dstToTarget < (chainGr.maxLenghtChain * 75) / 100)
        {
            chainController.ChangeState(lightState);
        }

        //controllo stress
        //if (chainController.currentStressValue >= 100)
        //{
        //  chainController.ChangeState(brokenState);
        //}

        chainController.ChainObstacle(brokenState);
    }
}
