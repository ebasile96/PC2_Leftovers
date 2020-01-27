using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject Enemy;

    public void InstantiateEnemy()
    {
        Enemy = ObjectPooler.SharedInstance.GetPooledObject();
        if(Enemy != null)
        {
            Enemy.transform.position = transform.position;
            Enemy.transform.rotation = transform.rotation;
            Enemy.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            InstantiateEnemy();
        }
    }
}
