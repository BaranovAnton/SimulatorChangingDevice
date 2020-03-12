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

    private DeviceModel currentDeviceModel;
    private int currentDeviceNumber = 0;

    private void Start()
    {
        foreach (Tutorial tutorial in tutorials)
        {
            // disable all devices
            tutorial.tutorialDevice.SetActive(false);

            // choose only indicated tutorial
            if (tutorial.tutorialNumber == TutorialNumber)
            {
                // enable only tutorial device
                tutorial.tutorialDevice.SetActive(true);

                // for all device controllers in tutorial
                foreach (Device device in tutorial.devices)
                {
                    // subscribe methon on device's models changing
                    device.deviceController.OnModelStateChanged += CheckUserActionInTutorial;
                }
            }
        }
    }

    // when any device in tutorial are changed state
    private void CheckUserActionInTutorial(DeviceModel deviceModel)
    {
        // if user done more actions when there are in tutorial - finish tutorial
        if (currentDeviceNumber >= tutorials[TutorialNumber].devices.Count - 1)
        {
            AppManager.instance.FinishTutorial();
            return;
        }

        // init current device model
        currentDeviceModel = tutorials[TutorialNumber].devices[currentDeviceNumber].deviceController.deviceModel;
        // check current device model and changed state device model
        if (currentDeviceModel == deviceModel)
        {
            // TODO: Add compare id devices and state changing

            Debug.Log("Correct action for tutorial");
            RightTutorialOrder();

            currentDeviceNumber++;
        } else
        {
            // TODO: Add counting of user mistakes

            Debug.Log("Incorrect action for tutorial");
            WrongTutorialOrder();
        }

        // draft
        /*if (deviceModel is ButtonModel)
        {
            ButtonModel buttonModel = (ButtonModel)deviceModel;
            if (buttonModel.State == ButtonStates.ButtonStateEnum.pressed)
            {
                print("нажата!");
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
    public GameObject tutorialDevice;   // prefab main device (combination of devices)
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