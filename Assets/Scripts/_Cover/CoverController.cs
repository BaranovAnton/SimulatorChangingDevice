using UnityEngine;

/// <summary>
/// Cover class controller: device logic and connection model-view
/// </summary>
public class CoverController : DeviceController
{
    public int id;
    public Material lockedMaterial, unlockedMaterial;
    public LockConstraints.LockAxis lockAxe;
    public Vector2 lockAxeValue;

    public CoverModel coverModel { get; private set; }
    public CoverView coverView { get; private set; }
    LockConstraints lockPosition;

    public override event ModelStateEvent OnModelStateChanged;

    private RotateDragObject dragObject;

    void Start()
    {
        CreateModelAndView();
        CreateDragObject();
    }

    private void CreateDragObject()
    {
        dragObject = gameObject.AddComponent<RotateDragObject>();
        dragObject.SetConstraints(Vector2.zero,
                                  Vector2.zero,
                                  new Vector2(lockPosition.lockedValue, lockPosition.unlockedValue));
    }

    private void CreateModelAndView()
    {
        lockPosition = new LockConstraints(lockAxe, lockAxeValue.x, lockAxeValue.y);
        coverModel = new CoverModel(id, LockAvailable.LockAvailableEnum.disable, OpenStates.OpenStateEnum.closed, lockPosition);
        deviceModel = coverModel;
        coverModel.OnStateChanged += LatchStateChanged;
        coverView = GetComponentInChildren<CoverView>();
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
            // Current z-axe value
            float defaultAxeValue = (transform.parent.eulerAngles.z > Mathf.Abs(lockPosition.unlockedValue - lockPosition.lockedValue))? 
                                        transform.parent.eulerAngles.z - 360 : transform.parent.eulerAngles.z;

            if (Mathf.Abs(lockPosition.unlockedValue - defaultAxeValue) < coverModel.LockDelta ||
                    Mathf.Abs(lockPosition.lockedValue - defaultAxeValue) < coverModel.LockDelta)
            {
                switch (coverModel.State)
                {
                    case OpenStates.OpenStateEnum.closed:
                        if (Mathf.Abs(lockPosition.unlockedValue - defaultAxeValue) < coverModel.LockDelta)
                            coverModel.State = OpenStates.OpenStateEnum.opened;
                        break;
                    case OpenStates.OpenStateEnum.opened:
                        if (Mathf.Abs(lockPosition.lockedValue - defaultAxeValue) < coverModel.LockDelta)
                            coverModel.State = OpenStates.OpenStateEnum.closed;
                        break;
                    default:
                        break;
                }
            }
        //}
    }

    private void LatchStateChanged(OpenStates.OpenStateEnum state)
    {
        switch (state)
        {
            case OpenStates.OpenStateEnum.closed:
                coverView.SetMaterial(lockedMaterial);
                break;
            case OpenStates.OpenStateEnum.opened:
                coverView.SetMaterial(unlockedMaterial);
                break;
            default:
                break;
        }

        if (OnModelStateChanged != null)
        {
            OnModelStateChanged(coverModel);
        }
    }
}