using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool;
    public int AmountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        PooledObjects = new List<GameObject>();
        for (int i = 0; i < AmountToPool; i++)
        {
            GameObject obj = Instantiate(ObjectToPool);
            obj.SetActive(false);
            PooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }    
        }
        return null;
    }
 
}
