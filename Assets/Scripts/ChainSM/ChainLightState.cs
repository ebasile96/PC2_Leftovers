using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightState : ChainBaseState
{
    public ChainController chainController;
    public FieldOfView fow;
    public ChainBaseState neutralState;
    public ChainBaseState mediumState;
    public ChainBaseState heavyState;

    public override void Enter()
    {
       
        //chainController = GetComponent<ChainController>();
        //fow = GetComponent<FieldOfView>();
    }

    public override void Tick()
    {
        Debug.Log("valore" + chainController.stressValue);
        fow.lineR.material = chainController.lightMaterial;
        if (chainController.stressValue >= 75)
        {
            chainController.ChangeState(mediumState);
        }

}
}
