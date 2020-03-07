using UnityEngine;

public class CoverController : MonoBehaviour
{
    public Material lockedMaterial, unlockedMaterial;
    public LockConstraints.LockAxis lockAxe;
    public Vector2 lockAxeValue;

    public CoverModel coverModel { get; private set; }
    public CoverView coverView { get; private set; }
    LockConstraints lockPosition;

    private RotateDragObject dragObject;

    void Start()
    {
        CreateModelAndView();

        dragObject = gameObject.AddComponent<RotateDragObject>();
        dragObject.SetConstraints(Vector2.zero, Vector2.zero, new Vector2(lockPosition.lockedValue, lockPosition.unlockedValue));
    }

    private void CreateModelAndView()
    {
        lockPosition = new LockConstraints(lockAxe, lockAxeValue.x, lockAxeValue.y);
        coverModel = new CoverModel(LockAvailable.LockAvailableEnum.disable, OpenStates.OpenStateEnum.closed, lockPosition);
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
            if (Mathf.Abs(lockPosition.unlockedValue - transform.localPosition.y) < coverModel.LockDelta ||
                Mathf.Abs(lockPosition.lockedValue - transform.localPosition.y) < coverModel.LockDelta)
            {
                switch (coverModel.State)
                {
                    case OpenStates.OpenStateEnum.closed:
                        coverModel.State = OpenStates.OpenStateEnum.opened;
                        break;
                    case OpenStates.OpenStateEnum.opened:
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
    }
}