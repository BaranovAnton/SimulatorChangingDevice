using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
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

        // refactoring: set constraints for all axes
        dragObject = gameObject.AddComponent<MoveDragObject>();
        dragObject.SetConstraints(new Vector2(transform.localPosition.x, transform.localPosition.x),
                                  new Vector2(lockPosition.lockedValue, lockPosition.unlockedValue),
                                  new Vector2(transform.localPosition.z, transform.localPosition.z));
    }

    private void CreateModelAndView()
    {
        lockPosition = new LockConstraints(lockAxe, lockAxeValue.x, lockAxeValue.y);
        latchModel = new LatchModel(LockAvailable.LockAvailableEnum.disable, LockStates.LockStateEnum.locked, lockPosition);
        latchModel.OnStateChanged += LatchStateChanged;
        latchView = GetComponentInChildren<LatchView>();
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
            if (Mathf.Abs(lockPosition.unlockedValue - transform.localPosition.y) < latchModel.LockDelta ||
                Mathf.Abs(lockPosition.lockedValue - transform.localPosition.y) < latchModel.LockDelta)
            {
                switch (latchModel.State)
                {
                    case LockStates.LockStateEnum.locked:
                        latchModel.State = LockStates.LockStateEnum.unlocked;
                        break;
                    case LockStates.LockStateEnum.unlocked:
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