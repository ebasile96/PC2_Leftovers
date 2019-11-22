using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public PlayerController playerCtrl;
    public GameObject secondCrystal;
    public GameObject ponte;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = FindObjectOfType<PlayerController>();
        secondCrystal.SetActive(false);
        ponte.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ActiveFirstCrystal();
        ActiveSecondCrystal();
    }

    public void ActiveFirstCrystal()
    {
        if(playerCtrl.isCrystal == true)
        {
            Debug.Log("si aativa cristallo");
            secondCrystal.SetActive(true);
        }
    }

    public void ActiveSecondCrystal()
    {
        if (playerCtrl.isSecondCrystal == true)
        {
            Debug.Log("si aativa  secondo cristallo");
            ponte.SetActive(true);
        }
    }
}
