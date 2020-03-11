using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceManager : MonoBehaviour
{
    public static DeviceManager instance = null;    // Singleton

    public int tutorialNumber;

    private List<Tutorial> tutorials;

    void Start()
    {  
        if (instance == null)
        {
            instance = this;
        }

        InitializeManager();
    }

    private void InitializeManager()
    {
        tutorials = GetComponent<Tutorials>().tutorials;
    }
}