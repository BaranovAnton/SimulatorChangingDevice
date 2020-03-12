using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public static AppManager instance = null;    // Singleton

    private TutorialDevice tutorialDevice;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        tutorialDevice = GetComponent<TutorialDevice>();
    }

    public void LaunchTutorial(int tutorialNumber)
    {
        tutorialDevice.
    }
}