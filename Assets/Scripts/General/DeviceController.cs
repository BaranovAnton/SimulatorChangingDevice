using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeviceController : MonoBehaviour
{
    public delegate void ModelStateEvent(DeviceModel deviceModel);
    public virtual event ModelStateEvent OnModelStateChanged;

    public DeviceModel deviceModel;
}