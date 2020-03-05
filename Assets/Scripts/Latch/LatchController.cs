using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchController : MonoBehaviour
{
    public LatchModel latchModel { get; private set; }
    public LatchView latchView { get; private set; }

    /*public LatchController(LatchModel latchModel, LatchView latchView)
    {
        this.latchModel = latchModel;
        this.latchView = latchView;
        this.latchModel.OnStateChanged += LatchStateChanged;
    }*/

    void Start()
    {
        this.latchModel = new LatchModel(LockAvailable.LockAvailableEnum.disable, LockStates.LockStateEnum.locked);
        this.latchView = GetComponentInChildren<LatchView>();
        this.latchModel.OnStateChanged += LatchStateChanged;
    }

    private void OnMouseDown()
    {
        // need to add a delay because of the animation

        switch(latchModel.State)
        {
            case LockStates.LockStateEnum.locked:
                latchModel.State = LockStates.LockStateEnum.unlocked;
                // play animation
                break;
            case LockStates.LockStateEnum.unlocked:
                latchModel.State = LockStates.LockStateEnum.locked;
                // play animation
                break;
            default:
                break;
        }
    }

    private void LatchStateChanged(LockStates.LockStateEnum state)
    {
        switch (state)
        {
            case LockStates.LockStateEnum.locked:
                latchView.SetColor(Color.red);
                break;
            case LockStates.LockStateEnum.unlocked:
                latchView.SetColor(Color.green);
                break;
            default:
                break;
        }
    }
}