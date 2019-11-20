using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatform : Platform
{
    int playerLayer = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            PlayerisFilled = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerisFilled = false;
    }
}
