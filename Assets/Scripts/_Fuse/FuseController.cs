using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fuse class controller: device logic and connection model-view
/// </summary>
public class FuseController : DeviceController
{
    public int id;
    public Material rightMaterial, wrongMaterial;
    public PositionStates.PositionStateEnum currentStatePosition;

    public FuseModel fuseModel { get; private set; }
    public FuseView fuseView { get; private set; }

    // Event when model changed
    public override event ModelStateEvent OnModelStateChanged;

    private MoveDragObject dragObject;
    private Transform fuseParent, appManager;
    private bool enterToFuseHolder;

    void Start()
    {
        CreateModelAndView();
        CreateDragObject();

        appManager = GameObject.FindGameObjectWithTag("AppManager").transform;
    }

    private void CreateModelAndView()
    {
        fuseModel = new FuseModel(id, LockAvailable.LockAvailableEnum.disable, currentStatePosition, WorkingStates.WorkingStateEnum.broken);
        deviceModel = fuseModel;
        fuseModel.OnPositionChanged += FuseStateChanged;
        fuseView = GetComponentInChildren<FuseView>();
    }

    private void CreateDragObject()
    {
        dragObject = gameObject.AddComponent<MoveDragObject>();
        dragObject.UseConstraints = false;
    }

    // intersection fuse and fuse-holder
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FuseHolder")
        {
            enterToFuseHolder = true;
            fuseParent = other.transform;
        }
    }

    // intersection fuse and fuse-holder
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FuseHolder")
        {
            enterToFuseHolder = false;
            fuseParent = appManager;
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

    private void FuseStateChanged(PositionStates.PositionStateEnum state)
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

        if (OnModelStateChanged != null)
        {
            OnModelStateChanged(fuseModel);
        }
    }
}