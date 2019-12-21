using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableController : MonoBehaviour
{
    public PlayerController player;
    void Start()
    {
        //pezza per presentazione 21
        player.GetComponent<PlayerController>().enabled = true;
        //
    }


}
