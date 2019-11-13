using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    EnemyController enemy;
    public EnemyStateBase idleState;

    public override void Enter()
    {
        enemy = GetComponent<EnemyController>();
    }

    public override void Tick()
    {
        //enemy.AttackMelee();

        //if(enemy.hit.collider.tag != "Player")
        {
            enemy.ChangeState(idleState);
        }
    }

    public override void Exit()
    {
       
    }
}
