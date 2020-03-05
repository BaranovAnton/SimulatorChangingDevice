using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceManager : MonoBehaviour
{
    private List<Device> devices;

    void Start()
    {
        
    }

    private void InitDevices()
    {

    }

    public void AddDevice(Device device)
    {
        devices.Add(device);
    }
}

public abstract class Device : MonoBehaviour
{
    private GameObject devicePrefab;
    public GameObject DevicePrefab { get; set; }
}

public class Fuse : Device
{
    public enum FuseTypes { fuseV1, fuseV2 }
    private FuseTypes fuseType;


}