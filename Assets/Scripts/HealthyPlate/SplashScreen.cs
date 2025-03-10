using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Starting Scene Switch");
        StartCoroutine(ScreenTimer());
    }

    IEnumerator ScreenTimer()
    {
        yield return new WaitForSeconds(3);

        Debug.Log("Swtiching Scenes");
        SceneManager.LoadScene("IntroScene");
    }
}
