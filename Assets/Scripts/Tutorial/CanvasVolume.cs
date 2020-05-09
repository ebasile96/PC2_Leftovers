using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasVolume : MonoBehaviour
{
    public GameObject sprite;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Pet")
        sprite.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Pet")
            sprite.SetActive(false);
    }
}
