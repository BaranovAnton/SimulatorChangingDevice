using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    public LockModel lockModel { get; private set; }
    public LockView lockView { get; private set; }

    public LockController(LockModel lockModel, LockView lockView)
    {
        this.lockModel = lockModel;
        this.lockView = lockView;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
