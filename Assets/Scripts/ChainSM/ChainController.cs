using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    public ChainBaseState currentState;
    public float currentStressValue;
    public float maxStressValue;
    public float reforgeStressValue;
    public FieldOfView fov;
    public float reforgeTimer;
    public float maxReforgeTimer;
    public Material lightMaterial;
    public Material mediumMaterial;
    public Material heavyMaterial;
    public Material neutralMaterial;

    public void ChangeState(ChainBaseState newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentState.Tick();
        LenghtStressChain();
        ChainBreaker();
        ChainReformer();
        
        Debug.Log("timer funziona " + reforgeTimer);
    }

    public void CheckChain()
    {
        if (fov.visibleTargets.Count == 0)
        {
            fov.lineR.enabled = false;
        }
        else if(fov.visibleTargets.Count == 0 && currentStressValue < 100)
        {
            fov.lineR.enabled = true;
        }
    }

    public void LenghtStressChain()
    {
        if(fov.dstToTarget >= 5 && currentStressValue <= 100)
        {
            currentStressValue += (((currentStressValue / 100) * fov.dstToTarget) / 60);
        }
        else if (currentStressValue > 1)
        {
            currentStressValue -= (((currentStressValue / 100) * fov.dstToTarget) / 60);
        }
    }

    public void ChainBreaker()
    {
        if(currentStressValue >= 100)
        {
            fov.lineR.enabled = false;
        }     
    }

    public void ChainReformer()
    {
        if(currentStressValue >= 100 && fov.dstToTarget <= 7)
        {
            reforgeTimer -= 1;
            Debug.Log("timer funziona " + reforgeTimer);
        }
        else if(currentStressValue >= 100 && fov.dstToTarget > 7)
        {
            reforgeTimer = maxReforgeTimer;
             Debug.Log("timer reset funziona ");
        }

        if(reforgeTimer <= 0)
        {
            fov.lineR.enabled = true;
            reforgeTimer = maxReforgeTimer;
            currentStressValue = reforgeStressValue;
        }
    }

}
