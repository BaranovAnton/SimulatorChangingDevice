using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class contains tutorials and checks user actions
/// </summary>
public class TutorialDevice : MonoBehaviour
{
    public List<Tutorial> tutorials;

    private int tutorialNumber;
    public int TutorialNumber { get => tutorialNumber; set => tutorialNumber = value; }

    private int currentDeviceNumber = 0;
    private List<int> tutorialDeviceOrder = new List<int>();

    public void InitTutorialDevice()
    {
        foreach (Tutorial tutorial in tutorials)
        {
            // choose only indicated tutorial
            if (tutorial.tutorialNumber == TutorialNumber)
            {
                // enable only tutorial devices
                for (int i = 0; i < tutorial.tutorialDevices.Length; i++)
                    tutorial.tutorialDevices[i].SetActive(true);

                // for all device controllers in tutorial
                foreach (Device device in tutorial.devices)
                {
                    // subscribe methon on device's models changing
                    device.deviceController.OnModelStateChanged += CheckUserActionInTutorial;
                    // order devices as they have to be activated
                    tutorialDeviceOrder.Add(device.deviceOrder);
                }
            }
        }
    }

    // when any device in tutorial are changed state
    private void CheckUserActionInTutorial(DeviceModel deviceModel)
    {
        // if user done more actions when there are in tutorial - finish tutorial
        if (currentDeviceNumber >= tutorials[TutorialNumber].devices.Count)
        {
            AppManager.instance.FinishTutorial();
            return;
        }

        // init current device, device model, etc.
        Device currentDevice = tutorials[TutorialNumber].devices[currentDeviceNumber];
        DeviceModel currentDeviceModel = currentDevice.deviceController.deviceModel;
        int currentDeviceOrder = currentDevice.deviceOrder;
        // check current device model and device order - changed state device model
        if (currentDeviceModel == deviceModel && currentDeviceOrder == tutorialDeviceOrder[currentDeviceNumber])
        {
            // TODO: Add compare id devices and state changing
            RightTutorialOrder();

            currentDeviceNumber++;
        } else
        {
            // TODO: Add counting of user mistakes
            WrongTutorialOrder();
        }

        // draft
        /*if (deviceModel is ButtonModel)
        {
            ButtonModel buttonModel = (ButtonModel)deviceModel;
            if (buttonModel.State == ButtonStates.ButtonStateEnum.pressed)
            {
            }
        }*/
    }

    private void RightTutorialOrder() { }
    private void WrongTutorialOrder() { }
}

/// <summary>
/// Class describes tutorial
/// </summary>
[Serializable]
public class Tutorial
{
    public string tutorialName; // just for information and convenience in Editor
    public int tutorialNumber;
    public GameObject[] tutorialDevices;   // prefabs of tutorial devices (or combination of devices)
    public List<Device> devices;    // all devices in tutorial
}

/// <summary>
/// Class describe tutorial device
/// </summary>
[Serializable]
public class Device
{
    public string deviceName;   // just for information and convenience in Editor
    public int deviceOrder;
    public DeviceController deviceController;

    // TODO: init device method where instantiate prefabs from Resources (or other) source
    // right now prefabs located on the scene by default
}