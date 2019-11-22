using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePet : MonoBehaviour
{
    public PlayerController playerCtrl;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = FindObjectOfType<PlayerController>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            //disattivo scudo
            playerCtrl.isShieldEnemy = false;

        }
        else if (collision.gameObject.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
       
    }
}
