using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class GenericVolume : MonoBehaviour
{
    public GameObject sprite;
    public GameObject target;

    private void Update()
    {
        sprite.transform.position = target.transform.position + new Vector3(0, 4.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        sprite.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        sprite.SetActive(false);
    }

}
