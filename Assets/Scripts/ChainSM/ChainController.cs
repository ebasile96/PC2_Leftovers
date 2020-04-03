using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChainController : MonoBehaviour
{
    public ChainGraphic graphic;
    public ChainBaseState currentState;
    public float currentStressValue;
    public float maxStressValue;
    public float reforgeStressValue;
    public float reforgeTimer;
    public float maxReforgeTimer;
    [SerializeField]
    public Ray rayChain;
    [SerializeField]
    RaycastHit hit;

    //grafica catena 
    public Material lightMaterial;
    public Material mediumMaterial;
    public Material heavyMaterial;
    public Material neutralMaterial;

    //variabili per attacco catena
    public float timerCombo;
    public float maxTimerCombo;
    public float comboExtender;
    public int enemyCounter;
    public float enemyStressValue;
    public float comboStressMultiplier;

    //provvissorio per test
    public Text testReforgeTimer;
    //provvisorio per test 
    public Text testTimerCombo;

    public void ChangeState(ChainBaseState newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentState.Tick();
        LenghtStressChain();
        ChainBreaker();
        ChainReformer();
        //CheckChain();
        attackChain();
        DecreaseComboTimer();
        NormalizedStressValue();

        //provvisorio per test
        testReforgeTimer.text = reforgeTimer.ToString();
        //provvisorio per test
        testTimerCombo.text = timerCombo.ToString();
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

    public void DrawRaycast()
    {
        rayChain = new Ray(transform.position, graphic.dirToTarget);
    }

    public void LenghtStressChain()
    {
        if (currentStressValue > 1)
        {
            currentStressValue -= (((currentStressValue / 100) * graphic.dstToTarget) / 20);
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

    private void attackChain()
    {
        if (Physics.Raycast(rayChain, out hit, graphic.dstToTarget) && hit.collider.tag == "Enemy")
        {
            if (timerCombo == 0 && currentStressValue != 100)
            {
                hit.collider.gameObject.SetActive(false);
                currentStressValue += enemyStressValue;
                enemyCounter = 1;
                timerCombo = maxTimerCombo;
                SoundManager.PlaySound(SoundManager.Sound.enemyTakeDamage);
            }
            else if (timerCombo != 0 && currentStressValue != 100)
            {
                hit.collider.gameObject.SetActive(false);
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
