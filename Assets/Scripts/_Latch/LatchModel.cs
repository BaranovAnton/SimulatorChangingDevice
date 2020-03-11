/// <summary>
/// Class describes Latch model
/// A latch is a type of mechanical fastener that joins two (or more) objects or surfaces while allowing for their regular separation.
/// </summary>
public class LatchModel : DeviceModel
{
    public delegate void StateEvent(LockStates.LockStateEnum state);
    public event StateEvent OnStateChanged;

    private LockStates.LockStateEnum _state;

    private LockConstraints lockPosition;  // позиция при которой устройство разблокировано/заблокировано (ось и значение)
    private float lockDelta = 0.1f;
    public float LockDelta { get => lockDelta; set => lockDelta = value; }

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