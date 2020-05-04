﻿using UnityEngine;
using UnityEngine.AI;

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
    [HideInInspector]
    public bool isCollisionReforme;
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
    public VFXManager vfx;

    //variabili bonus Stress
    public PlayerLifeController pLife;
    public float bonusStressLife;

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
        //ChainBreaker();
        //ChainReformer();
        //CheckChain();
        DrawRaycastChain();
        attackChain();
        DecreaseComboTimer();
        NormalizedStressValue();
        //ChainObstacle();
    }

    public void LenghtStressChain()
    {
        if (currentStressValue > 1 && currentStressValue != 100)
        {
            currentStressValue -= (((currentStressValue / 100) * (graphic.maxLenghtChain - graphic.dstToTarget) / 20));
        }
    }

    /*public void ChainBreaker()
    {
      
       graphic.lineR.enabled = false;

    }*/

   // public bool isActiveChain;
    public void ChainReformer()
    {
        if(graphic.dstToTarget <= 7)
        {
            reforgeTimer -= 1;

            //Debug.Log("timer funziona " + reforgeTimer);
        }
        else if (graphic.dstToTarget > 7)
        {
            reforgeTimer = maxReforgeTimer;
             //Debug.Log("timer reset funziona ");
        }

        //if(reforgeTimer <= 0)
        //{
        //graphic.lineR.enabled = true;
        //reforgeTimer = maxReforgeTimer;
        //currentStressValue = reforgeStressValue;
        //}
    }

    private void DrawRaycastChain()
    {
        rayChain = new Ray(transform.position, graphic.dirToTarget);
    }

    private void attackChain()
    {
        if (Physics.Raycast(rayChain, out hit, graphic.dstToTarget) && hit.collider.tag == "Enemy")
        {
            if (timerCombo == 0 && graphic.lineR.enabled == true)
            {
                GameObject gameObject = Instantiate(vfx.vfxEnemyDeath);
                gameObject.transform.position = hit.point;
                Destroy(hit.collider.gameObject);
                lvlmgr._EnemyCounterAlive--;
                currentStressValue += enemyStressValue;
                enemyCounter = 1;
                timerCombo = maxTimerCombo;
                SoundManager.PlaySound(SoundManager.Sound.enemyTakeDamage);
            }
            else if (timerCombo != 0 && graphic.lineR.enabled == true)
            {
                GameObject gameObject = Instantiate(vfx.vfxEnemyDeath);
                gameObject.transform.position = hit.point;
                Destroy(hit.collider.gameObject);
                lvlmgr._EnemyCounterAlive--;
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

    public void ChainObstacle(ChainBaseState newState)
    {
        if (Physics.Raycast(rayChain, out hit, graphic.dstToTarget) && hit.collider.tag == "Obstacle")
        {
            currentStressValue = 0;
            graphic.lineR.enabled = false;
            newState.Enter();
            currentState = newState;
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
        if (currentStressValue >= 100)
        {
            currentStressValue = reforgeStressValue;
            BonusStress();
        }
    }

    public void ReformeChainCollision()
    {
        if (graphic.lineR.enabled == false)
        {
            currentStressValue = reforgeStressValue;
            reforgeTimer = maxReforgeTimer;
            isCollisionReforme = true;
        }
    }

    public void BonusStress()
    {
        pLife.healthPlayer += bonusStressLife;
        Debug.Log("cura");
    }
}
