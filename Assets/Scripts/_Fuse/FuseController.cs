using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseController : MonoBehaviour
{
    public Material rightMaterial, wrongMaterial;

    public FuseModel fuseModel { get; private set; }
    public FuseView fuseView { get; private set; }

    private MoveDragObject dragObject;
    private Transform fuseParent;
    private bool enterToFuseHolder;

    void Start()
    {
        CreateModelAndView();
        CreateDragObject();
    }

    private void CreateModelAndView()
    {
        fuseModel = new FuseModel(LockAvailable.LockAvailableEnum.disable, PositionStates.PositionStateEnum.wrongPos, WorkingStates.WorkingStateEnum.broken);
        fuseModel.OnPositionChanged += LatchStateChanged;
        fuseView = GetComponentInChildren<FuseView>();
    }

    private void CreateDragObject()
    {
        dragObject = gameObject.AddComponent<MoveDragObject>();
        dragObject.UseConstraints = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FuseHolder")
        {
            enterToFuseHolder = true;
            fuseParent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FuseHolder")
        {
            enterToFuseHolder = false;
            fuseParent = null;
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
            if (enterToFuseHolder)
            {
                transform.parent = fuseParent;
                transform.localPosition = Vector3.zero;

                fuseModel.Place = PositionStates.PositionStateEnum.rightPos;
            } else
            {
                transform.parent = null;

                fuseModel.Place = PositionStates.PositionStateEnum.wrongPos;
            }
        //}
    }

    private void LatchStateChanged(PositionStates.PositionStateEnum state)
    {
        switch (state)
        {
            case PositionStates.PositionStateEnum.rightPos:
                fuseView.SetMaterial(rightMaterial);
                break;
            case PositionStates.PositionStateEnum.wrongPos:
                fuseView.SetMaterial(wrongMaterial);
                break;
            default:
                break;
        }
    }
}