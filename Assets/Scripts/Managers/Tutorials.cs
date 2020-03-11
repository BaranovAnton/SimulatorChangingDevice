using System;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    private const int tutorialNumber = 1;

    public List<Tutorial> tutorials;

    private List<int> rightDeviceOrder = new List<int>();

    private void Start()
    {
        foreach (Tutorial tutorial in tutorials)
        {
            // Choose only indicated tutorial
            if (tutorial.tutorialNumber == tutorialNumber)
            {
                // For all device controllers in tutorial
                foreach (Device device in tutorial.devices)
                {
                    if (!rightDeviceOrder.Contains(device.deviceOrder))
                        rightDeviceOrder.Add(device.deviceOrder);

                    device.deviceController.OnModelStateChanged += CheckUserActionInTutorial;
                }
            }
        }
    }

    // подписать метод на изменения состояния всех устройств в выбранном туториале
    private void CheckUserActionInTutorial(DeviceModel deviceModel)
    {
        bool correct = false;

        // проверка
        //if (deviceModel)

        if (correct)
        {
            Debug.Log("Right action for tutorial");
            RightTutorialOrder();
        } else
        {
            Debug.Log("Wrong action for tutorial");
            WrongTutorialOrder();
        }
    }

    private void RightTutorialOrder()
    {
        // to the next step

    }

    private void WrongTutorialOrder()
    {
        // show menu: step back? or again?

    }
}

[Serializable]
public class Tutorial
{
    public string tutorialName; // Just for information and convenience in Editor
    public int tutorialNumber;
    public List<Device> devices;
}

[Serializable]
public class Device
{
    public string deviceName;   // Just for information and convenience in Editor
    public int deviceOrder;
    public DeviceController deviceController;
}