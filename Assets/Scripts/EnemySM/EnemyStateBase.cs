using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBase : MonoBehaviour
{
    protected EnemyController enemy;

    private void Awake()
    {
      enemy = GetComponentInParent<EnemyController>();
    }

    public virtual void Enter()
    {

    }

    public virtual void Tick()
    {

    }

    public virtual void Exit()
    {

    }
}
