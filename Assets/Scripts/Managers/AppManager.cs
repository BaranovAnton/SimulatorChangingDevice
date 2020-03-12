using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class controls application work
/// </summary>
public class AppManager : MonoBehaviour
{
    public static AppManager instance = null;    // singleton

    public GameObject startScreen, finishScreen;

    private TutorialDevice tutorialDevice;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        tutorialDevice = GetComponent<TutorialDevice>();
        finishScreen.SetActive(false);

        // disable all devices
        for (int i=0; i<transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }

    public void StartTutorial(int tutorialNumber)
    {
        Debug.Log("Start tutorial #" + tutorialNumber);
        tutorialDevice.TutorialNumber = tutorialNumber;
        tutorialDevice.InitTutorialDevice();
        startScreen.SetActive(false);
        // TODO: timer start
    }

    public void FinishTutorial()
    {
        Debug.Log("Finish tutorial");
        finishScreen.SetActive(true);
        // TODO: timer stop
    }

    public void ReloadTutorial()
    {
        Debug.Log("Reload tutorial");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}