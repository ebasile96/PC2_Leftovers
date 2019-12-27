using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy  
{
    void Attack(GameObject target);
    void FollowPlayer();
}
