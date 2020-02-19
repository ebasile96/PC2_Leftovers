using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    LineRenderer lineR;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public Transform targetLine;

    //[HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();
    

    void Start()
    {
        lineR = GetComponent<LineRenderer>();
        //StartCoroutine("FindTargetsWithDelay", .2f);
    }


   /* IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }*/

    private void Update()
    {
        FindVisibleTargets();
        CheckChain();
    }

    public void CheckChain()
    {
        if(visibleTargets.Count == 0)
        {
            lineR.enabled = false;
        }
        else
        {
            lineR.enabled = true;
        }
    }
    
    #region test
    Transform enemy;
    #endregion
    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        Collider[] enemiesInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, obstacleMask);

        for (int i = 0; i < enemiesInViewRadius.Length; i++)
        {
            enemy = enemiesInViewRadius[i].transform;
        }

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            targetLine = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (targetLine.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, targetLine.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(targetLine);
                    
                }
                else
                {
                    obstacleMask.Equals(enemy);
                    enemy.gameObject.SetActive(false);
                    SoundManager.PlaySound(SoundManager.Sound.enemyTakeDamage);
                }
                //else
                //{

                //    Debug.Log("danno");
                //    visibleTargets.Add(enemy);
                //    foreach (Transform obstacle in visibleTargets)
                //    {
                //        enemy = obstacle;
                //        enemy.gameObject.SetActive(false);
                //    }


                //}
                

                lineR.SetPosition(0, transform.position);
                lineR.SetPosition(1, targetLine.position);
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
