using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchController : MonoBehaviour
{
    public Material lockedMaterial, unlockedMaterial;

    public LatchModel latchModel { get; private set; }
    public LatchView latchView { get; private set; }

    private DragObject dragObject;

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

        dragObject = this.gameObject.AddComponent<DragObject>();
        dragObject.SetConstraints(1.0f, 1.0f, -0.9f, 0.5f, 0f, 0f);
    }

    private void OnMouseDown()
    {
        // need to add a delay because of the animation

        /*switch(latchModel.State)
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
        }*/

        dragObject.StartDrag();
    }

    private void OnMouseDrag()
    {
        dragObject.Drag();
    }

    private void OnMouseUp()
    {
        float delta = Mathf.Abs(0.5f - transform.position.y);
        if (delta < 0.1f)
        {

        }
    }

    private void LatchStateChanged(LockStates.LockStateEnum state)
    {
        switch (state)
        {
            case LockStates.LockStateEnum.locked:
                latchView.SetMaterial(lockedMaterial);
                break;
            case LockStates.LockStateEnum.unlocked:
                latchView.SetMaterial(lockedMaterial);
                break;
            default:
                break;
        }
    }
}