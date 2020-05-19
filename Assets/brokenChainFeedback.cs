using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class brokenChainFeedback : MonoBehaviour
{
    [SerializeField] feedManager FeedMgr;
    public GameObject arrow1, arrow2, arrow3;
    public Transform target;
    float distToTarget;
    Vector3 dirToTarget;
    Ray ray;
    RaycastHit hit;
    

    private void Update()
    {

        if(target != null)
            Checkdistance();

        if (FeedMgr.ChainIsBroken)
        {
            SpriteActivation();
            spriteDirection();
        }
        else if (!FeedMgr.ChainIsBroken)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
        }

            
    }

    //controllo la distanza tra i player
    public void Checkdistance()
    {
        dirToTarget = (target.transform.position - transform.position).normalized;
        distToTarget = Vector3.Distance(transform.position, target.position);
        ray = new Ray(transform.position, dirToTarget);
        if (Physics.Raycast(ray, out hit, distToTarget))
        {
            distToTarget = hit.distance;
        }
    }

    //attivo le sprite in base alla distanza
    public void SpriteActivation()
    {
        if(distToTarget >= 10)
        {
            arrow1.SetActive(true);
            arrow2.SetActive(true);
            arrow3.SetActive(true);
        }
        else if(distToTarget < 10 && distToTarget > 5)
        {
            arrow1.SetActive(true);
            arrow2.SetActive(true);
            arrow3.SetActive(false);
        }
        else if (distToTarget < 5 && distToTarget > 1.5f)
        {
            arrow1.SetActive(true);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
        }
    }

    public void spriteDirection()
    {
        transform.LookAt(target.transform.position);
    }
}
