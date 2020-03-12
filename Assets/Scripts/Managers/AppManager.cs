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
    }

    public void StartTutorial(int tutorialNumber)
    {
        Debug.Log("Start tutorial #" + tutorialNumber);
        tutorialDevice.TutorialNumber = tutorialNumber;
        startScreen.SetActive(false);
    }

    public void FinishTutorial()
    {
        Debug.Log("Finish tutorial");
        finishScreen.SetActive(true);
    }

    public void ReloadTutorial()
    {
        Debug.Log("Reload tutorial");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}