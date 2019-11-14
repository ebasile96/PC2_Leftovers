using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    public EnemyStateBase movementState;


    public override void Enter()
    {
        enemy = GetComponent<EnemyController>();
        
    }

    public override void Tick()
    {
        /*enemy.AttackMelee();
        if (enemy.isPlayer == false)
        {
            Debug.Log("entra nello stao nuovo");
            enemy.ChangeState(movementState);
        }
        enemy.TakeDamagePlayer();*/
        
    }

    public override void Exit()
    {
       
    }
}
