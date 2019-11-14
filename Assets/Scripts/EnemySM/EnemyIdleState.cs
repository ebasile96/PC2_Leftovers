using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyStateBase
{
    EnemyController enemy;
    public EnemyStateBase attackState;

    public override void Enter()
    {
        enemy = GetComponent<EnemyController>();
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {

    }
}
