using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class StateBehaviourBase : StateMachineBehaviour
{
    protected GameManager.Context ctx = new GameManager.Context();

    public void Setup(GameManager.Context _ctx)
    {

        ctx = _ctx;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnEnter();
    }
    public virtual void OnEnter() { }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnUpdate();
    }

    public virtual void OnUpdate() { }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnExit();
    }
    public virtual void OnExit() { }
}

