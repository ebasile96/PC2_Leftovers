using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatform : Platform
{
    int playerLayer = 10;
    
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(mesh.material.color);
        if (other.gameObject.layer == playerLayer)
        {
            PlayerisFilled = true;
            mesh.material.color = new Color(0, 1, 0);
            Debug.Log(mesh.material.color);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerisFilled = false;
    }
}
