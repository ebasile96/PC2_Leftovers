using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StessBarController : MonoBehaviour
{
    public ChainController chainController;
    public float stressLenght;
    public float weakSpell = 0.1f;
    public GameObject stressBar;

    // Start is called before the first frame update
    void Start()
    {
        chainController = FindObjectOfType<ChainController>();
    }

    // Update is called once per frame
    void Update()
    {
        stressLenght = chainController.currentStressValue;
        stressBar.GetComponent<RectTransform>().sizeDelta = new Vector2(stressLenght, 100);
    }
}
