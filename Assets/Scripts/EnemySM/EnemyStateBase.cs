using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBase : MonoBehaviour
{
    protected Enemy enemy;

    private void Awake()
    {
      enemy = GetComponentInParent<Enemy>();
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
