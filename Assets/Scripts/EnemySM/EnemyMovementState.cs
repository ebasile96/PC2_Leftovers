using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementState : EnemyStateBase
{
    public EnemyStateBase attackState;

    public override void Enter()
    {

    }

    public override void Tick()
    {
        enemy.FollowPlayer();

        //enemy.AttackMelee();
        /*if (enemy.hit.collider.tag == "Player")
        {
            Debug.Log("entra if");
            enemy.ChangeState(attackState);
        }*/
    }

    public override void Exit()
    {

    }
}
