using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LogicProjectile : MonoBehaviour
{
    private PlayerLifeController pLife;
    public PlayerController player;
    public PatrolAgent agent;
    public Vector3 target;
    public int damageArrow;
    // Start is called before the first frame update
    void Start()
    {
        pLife = FindObjectOfType<PlayerLifeController>();
        agent = FindObjectOfType<PatrolAgent>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //target = player.transform.position;
        //agent.projectile.transform.DOMove(target, 2);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            if (player.invulnerabilityCounter <= 0)
            {
                pLife.TakeDamage(damageArrow);
                player.invulnerabilityCounter = player.invulnerabilityTimer;
            }
        }
        else if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Untagged")
        {
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
