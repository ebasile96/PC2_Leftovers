using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChainController : MonoBehaviour
{
    public ChainGraphic graphic;
    public ChainBaseState currentState;
    LevelManager lvlmgr;
    public float currentStressValue;
    public float maxStressValue;
    public float reforgeStressValue;
    public float reforgeTimer;
    public float maxReforgeTimer;
    [SerializeField]
    public Ray rayChain;
    [SerializeField]
    RaycastHit hit;

    //variabili per attacco catena
    public float timerCombo;
    public float maxTimerCombo;
    public float comboExtender;
    public int enemyCounter;
    public float enemyStressValue;
    public float comboStressMultiplier;

    public void ChangeState(ChainBaseState newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    // Start is called before the first frame update
    void Start()
    {
        lvlmgr = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Tick();
        LenghtStressChain();
        ChainBreaker();
        ChainReformer();
        //CheckChain();
        DrawRaycastChain();
        attackChain();
        DecreaseComboTimer();
        NormalizedStressValue();
        ChainObstacle();
    }

    /*public void CheckChain()
    {
        if (fov.visibleTargets.Count == 0)
        {
            fov.lineR.enabled = false;
        }
        else if(fov.visibleTargets.Count != 0 && currentStressValue < 100)
        {
            fov.lineR.enabled = true;
        }
    }*/


    public void LenghtStressChain()
    {
        if (currentStressValue > 1)
        {
            currentStressValue -= (((currentStressValue / 100) * (graphic.maxLenghtChain - graphic.dstToTarget) / 20));
        }
    }

    public void ChainBreaker()
    {
        if(currentStressValue >= 100)
        {
            graphic.lineR.enabled = false;
        }     
    }

    public void ChainReformer()
    {
        if(currentStressValue >= 100 && graphic.dstToTarget <= 7)
        {
            reforgeTimer -= 1;
            //Debug.Log("timer funziona " + reforgeTimer);
        }
        else if(currentStressValue >= 100 && graphic.dstToTarget > 7)
        {
            reforgeTimer = maxReforgeTimer;
             //Debug.Log("timer reset funziona ");
        }

        if(reforgeTimer <= 0)
        {
            graphic.lineR.enabled = true;
            reforgeTimer = maxReforgeTimer;
            currentStressValue = reforgeStressValue;
        }
    }

    private void DrawRaycastChain()
    {
        rayChain = new Ray(transform.position, graphic.dirToTarget);
    }

    private void attackChain()
    {
        if (Physics.Raycast(rayChain, out hit, graphic.dstToTarget) && hit.collider.tag == "Enemy")
        {
            if (timerCombo == 0 && currentStressValue != 100)
            {
                Destroy(hit.collider.gameObject);
                lvlmgr.EnemiesAlive.Remove(hit.collider.gameObject);
                currentStressValue += enemyStressValue;
                enemyCounter = 1;
                timerCombo = maxTimerCombo;
                SoundManager.PlaySound(SoundManager.Sound.enemyTakeDamage);
            }
            else if (timerCombo != 0 && currentStressValue != 100)
            {
                Destroy(hit.collider.gameObject);
                lvlmgr.EnemiesAlive.Remove(hit.collider.gameObject);
                enemyCounter += 1;
                if (timerCombo < maxTimerCombo)
                {
                    timerCombo += comboExtender;
                }
                currentStressValue += (enemyStressValue * (1 - (comboStressMultiplier * enemyCounter)));
                SoundManager.PlaySound(SoundManager.Sound.enemyTakeDamage);
            }
        }
    }

    private void ChainObstacle()
    {
        if (Physics.Raycast(rayChain, out hit, graphic.dstToTarget) && hit.collider.tag == "Obstacle")
        {
            currentStressValue = 100;
            graphic.lineR.enabled = false;
        }
    }

    private void DecreaseComboTimer()
    {
        if (timerCombo > 0)
        {
            timerCombo -= 1;
        }
    }

    private void NormalizedStressValue()
    {
        if (currentStressValue > 100)
        {
            currentStressValue = 100;
        }
    }

}
