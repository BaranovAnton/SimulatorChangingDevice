/// <summary>
/// Class for Latch model
/// </summary>
public class LatchModel : DeviceModel
{
    public delegate void StateEvent(LockStates.LockStateEnum state);
    public event StateEvent OnStateChanged;

    private LockStates.LockStateEnum _state;

    private LockConstraints lockPosition;
    private float lockDelta = 0.1f;
    public float LockDelta { get => lockDelta; set => lockDelta = value; }

    // latch model constructor
    public LatchModel(int id, LockAvailable.LockAvailableEnum available, LockStates.LockStateEnum state, LockConstraints lockPosition)
    {
        DeviceID = id;
        Available = available;
        State = state;
        this.lockPosition = lockPosition;
    }

    public LockStates.LockStateEnum State {
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