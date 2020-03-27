using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public LineRenderer lineR;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public LayerMask propsMask;
    public Transform targetLine;
    public float dstToTarget;
    public float timerCombo;
    public float maxTimerCombo;
    public float comboExtender;
    public int enemyCounter;
    public float enemyStressValue;
    public float comboStressMultiplier;
    public ChainController chainController;

    //[HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    //provvisorio per test 
    public Text testTimerCombo;

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
        DecreaseComboTimer();
        //CheckChain();
        /*if(chain.stressValue > 50)
        {
            lineR.material = lightMaterial;
        }*/

        //provvisorio per test
        testTimerCombo.text = timerCombo.ToString();
    }

    /*public void CheckChain()
    {
        if(visibleTargets.Count == 0)
        {
            lineR.enabled = false;
        }
        else
        {
            lineR.enabled = true;
        }
    }*/
    
    #region test
    Transform enemy;
    #endregion
    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        Collider[] enemiesInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, obstacleMask);
        Collider[] obstacleInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, propsMask);

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
                dstToTarget = Vector3.Distance(transform.position, targetLine.position);

                if(Physics.Raycast(transform.position, dirToTarget, dstToTarget, propsMask))
                {
                    lineR.enabled = false;
                    chainController.currentStressValue = 100;
                }

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(targetLine); 
                }
                else if(timerCombo == 0 && chainController.currentStressValue != 100)
                {
                    obstacleMask.Equals(enemy);
                    enemy.gameObject.SetActive(false);
                    chainController.currentStressValue += enemyStressValue;
                    enemyCounter = 1;
                    timerCombo = maxTimerCombo;
                    SoundManager.PlaySound(SoundManager.Sound.enemyTakeDamage);
                }
                else if (timerCombo != 0 && chainController.currentStressValue != 100)
                {
                    obstacleMask.Equals(enemy);
                    enemy.gameObject.SetActive(false);
                    enemyCounter += 1;
                    if (timerCombo < maxTimerCombo)
                    {
                        timerCombo += comboExtender;
                    }
                    chainController.currentStressValue += (enemyStressValue * (1 - (comboStressMultiplier * enemyCounter)));
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

    public void DecreaseComboTimer()
    {
        if (timerCombo > 0)
        {
            timerCombo -= 1;
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
