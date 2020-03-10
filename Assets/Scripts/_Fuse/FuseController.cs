using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchController : MonoBehaviour
{
    public Material lockedMaterial, unlockedMaterial;
    public LockConstraints.LockAxis lockAxe;
    public Vector2 lockAxeValue;

    public LatchModel latchModel { get; private set; }
    public LatchView latchView { get; private set; }
    LockConstraints lockPosition;

    private MoveDragObject dragObject;

    void Start()
    {
        CreateModelAndView();
        CreateDragObject();
    }

    private void CreateModelAndView()
    {
        lockPosition = new LockConstraints(lockAxe, lockAxeValue.x, lockAxeValue.y);
        latchModel = new LatchModel(LockAvailable.LockAvailableEnum.disable, LockStates.LockStateEnum.locked, lockPosition);
        latchModel.OnStateChanged += LatchStateChanged;
        latchView = GetComponentInChildren<LatchView>();
    }

    private void CreateDragObject()
    {
        dragObject = gameObject.AddComponent<MoveDragObject>();

        Vector2 defaultX = new Vector2(transform.localPosition.x, transform.localPosition.x);
        Vector2 defaultY = new Vector2(transform.localPosition.y, transform.localPosition.y);
        Vector2 defaultZ = new Vector2(transform.localPosition.z, transform.localPosition.z);

        switch (lockPosition.axis)
        {
            case LockConstraints.LockAxis.x:
                dragObject.SetConstraints(lockAxeValue, defaultY, defaultZ);
                break;
            case LockConstraints.LockAxis.y:
                dragObject.SetConstraints(defaultX, lockAxeValue, defaultZ);
                break;
            case LockConstraints.LockAxis.z:
                dragObject.SetConstraints(defaultX, defaultY, lockAxeValue);
                break;
            default:
                break;
        }
    }

    private void OnMouseDown()
    {
        //if (latchModel.Available == LockAvailable.LockAvailableEnum.enamble)
            dragObject.StartDrag();
    }

    private void OnMouseDrag()
    {
        //if (latchModel.Available == LockAvailable.LockAvailableEnum.enamble)
            dragObject.Drag();
    }

    private void OnMouseUp()
    {
        /*if (latchModel.Available == LockAvailable.LockAvailableEnum.enamble)
        {*/
            // Choosing axe value depends of latch moving direction
            float defaultAxeValue = (lockAxe == LockConstraints.LockAxis.x) ? transform.localPosition.x :
                                    (lockAxe == LockConstraints.LockAxis.y) ? transform.localPosition.y : transform.localPosition.z;

            if (Mathf.Abs(lockPosition.unlockedValue - defaultAxeValue) < latchModel.LockDelta ||
                Mathf.Abs(lockPosition.lockedValue - defaultAxeValue) < latchModel.LockDelta)
            {
                switch (latchModel.State)
                {
                    case LockStates.LockStateEnum.locked:
                        if (Mathf.Abs(lockPosition.unlockedValue - defaultAxeValue) < latchModel.LockDelta)
                            latchModel.State = LockStates.LockStateEnum.unlocked;
                        break;
                    case LockStates.LockStateEnum.unlocked:
                        if (Mathf.Abs(lockPosition.lockedValue - defaultAxeValue) < latchModel.LockDelta)
                            latchModel.State = LockStates.LockStateEnum.locked;
                        break;
                    default:
                        break;
                }
            }
        //}
    }

    private void LatchStateChanged(LockStates.LockStateEnum state)
    {
        switch (state)
        {
            case LockStates.LockStateEnum.locked:
                latchView.SetMaterial(lockedMaterial);
                break;
            case LockStates.LockStateEnum.unlocked:
                latchView.SetMaterial(unlockedMaterial);
                break;
            default:
                break;
        }
    }
}