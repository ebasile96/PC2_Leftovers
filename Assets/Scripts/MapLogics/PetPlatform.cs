using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPlatform : Platform
{
    int petLayer = 11;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == petLayer)
        {
            PetisFilled = true;
            mesh.material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PetisFilled = false;
    }
}
