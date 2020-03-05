using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    public EnemyStateBase movementState;
    public EnemyController enemyController;

    public override void Enter()
    {
        enemy = GetComponent<Enemy>();
    }

    public override void Tick()
    {
        //enemyController.StartCoroutine(enemyController.AttackMelee());
        /*if (enemy.isPlayer == false)
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
