using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadious;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    

    //[HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
        
        StartCoroutine("FindTargetWithDelay", .2f);
    }


    //Delay mi dice ogni quanto far partire la couroutine
    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
            
        }
    }

    void FindVisibleTarget()
    {
        visibleTargets.Clear();
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadious, targetMask);
        for (int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle/2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    //cosa fare quando il target è colpito dal raycast
                    //aggiungo a una lista la transform di tutti i target visibili
                    visibleTargets.Add(target);
                    
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }    
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
