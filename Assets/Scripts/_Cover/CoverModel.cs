/// <summary>
/// Class for Cover model
/// </summary>
public class CoverModel : DeviceModel
{
    public delegate void StateEvent(OpenStates.OpenStateEnum state);
    public event StateEvent OnStateChanged;

    private OpenStates.OpenStateEnum _state;    // cover state

    private LockConstraints openPosition;  // position when cover is opened/closed
    private float lockDelta = 5f;
    public float LockDelta { get => lockDelta; set => lockDelta = value; }

    public CoverModel(int id, LockAvailable.LockAvailableEnum available, OpenStates.OpenStateEnum state, LockConstraints openPosition)
    {
        DeviceID = id;
        Available = available;
        State = state;
        this.openPosition = openPosition;
    }

    public OpenStates.OpenStateEnum State {
        get {
            return _state;
        }
        set {
            if (_state != value)
            {
                _state = value;
                if (OnStateChanged != null)
                {
                    OnStateChanged(value);
                }
            }
        }
    }
}