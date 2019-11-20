using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PetPlatform pet;
    public PlayerPlatform player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (pet.PetisFilled == true && player.PlayerisFilled == true)
            OpenDoor();
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
