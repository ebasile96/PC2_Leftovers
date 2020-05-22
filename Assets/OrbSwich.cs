using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrbSwich : MonoBehaviour
{
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isSwapPlayer == false) 
        {
            transform.DOMove(player.transform.position, 0.75f);
        }
        else if(player.isSwapPlayer == true)
        {
            transform.DOMove(player.pet.transform.position, 0.75f);
        }
    }
}
