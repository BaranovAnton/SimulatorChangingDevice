using System;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDevice : MonoBehaviour
{
    private const int tutorialNumber = 0;

    public List<Tutorial> tutorials;

    private DeviceModel currentDeviceModel;
    private int currentDeviceNumber = 0;

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
                    device.deviceController.OnModelStateChanged += CheckUserActionInTutorial;
                }
            }
        }
    }

    // подписать метод на изменения состояния всех устройств в выбранном туториале
    private void CheckUserActionInTutorial(DeviceModel deviceModel)
    {
        if (tutorials[tutorialNumber].devices.Count >= currentDeviceNumber)
            return;

        // проверяем текущий верхний элемент из стэка туториала
        currentDeviceModel = tutorials[tutorialNumber].devices[currentDeviceNumber].deviceController.deviceModel;
        if (currentDeviceModel == deviceModel)
        {
            Debug.Log("Right action for tutorial");
            RightTutorialOrder();

            currentDeviceNumber++;
        } else
        {
            Debug.Log("Wrong action for tutorial");
            WrongTutorialOrder();
        }

        /*if (deviceModel is ButtonModel)
        {
            ButtonModel buttonModel = (ButtonModel)deviceModel;
            if (buttonModel.State == ButtonStates.ButtonStateEnum.pressed)
            {
                print("нажата!");
            }
        }*/
    }

    private void RightTutorialOrder()
    {
        
    }

    private void WrongTutorialOrder()
    {
        
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