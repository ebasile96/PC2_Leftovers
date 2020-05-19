using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedManager : MonoBehaviour
{
    [HideInInspector]public bool ChainIsBroken;
    [SerializeField] ChainBrokenState chainbrokenstate;
    private void Start()
    {
        //eventi che mi consentono di controllare lo stato della catena
        chainbrokenstate.ChainBrokenCall(() =>
        {
            ChainIsBroken = true;
        });

        chainbrokenstate.ChainReforgedCall(() =>
        {
            ChainIsBroken = false;
        });
    }
}
