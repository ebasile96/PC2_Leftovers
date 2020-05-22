using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrbSwichPet : MonoBehaviour
{
    PetController pet;

    // Start is called before the first frame update
    void Start()
    {
        pet = FindObjectOfType<PetController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pet.player.isSwapPlayer == false)
        {
            transform.DOMove(pet.transform.position, 0.75f);
        }
        else if (pet.player.isSwapPlayer == true)
        {
            transform.DOMove(pet.player.transform.position, 0.75f);
        }
    }
}
