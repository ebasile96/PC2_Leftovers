using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationIntroController : MonoBehaviour
{
    public GameObject animPanel01;
    public GameObject animPanel02;
    public GameObject animPanel03;


    // Start is called before the first frame update
    void Start()
    {
        animPanel01.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(AnimationIntro());
    }

    public IEnumerator AnimationIntro()
    {
        animPanel02.SetActive(true);
        yield return new WaitForSeconds(3.3f);
        animPanel02.SetActive(false);
        Destroy(animPanel02);
        animPanel03.SetActive(true);
        yield return new WaitForSeconds(3.3f);
        animPanel03.SetActive(false);
        animPanel01.SetActive(true);
        SceneManager.LoadScene("MM");
    }
}
