/// <summary>
/// Класс модели защёлки
/// </summary>
public class LatchModel
{
    public delegate void AvailableEvent(LockAvailable.LockAvailableEnum available);
    public event AvailableEvent OnAvailableChanged;

    public delegate void StateEvent(LockStates.LockStateEnum state);
    public event StateEvent OnStateChanged;

    private LockAvailable.LockAvailableEnum _available;     // доступно ли устройство для взаимодействия? (смены состояния)
    private LockStates.LockStateEnum _state;    // состояние устройства? открыто/закрыто

    private LockConstraints lockPosition;  // позиция при которой устройство разблокировано/заблокировано (ось и значение)
    private float lockDelta = 0.1f;
    public float LockDelta { get => lockDelta; set => lockDelta = value; }

    public LatchModel(LockAvailable.LockAvailableEnum available, LockStates.LockStateEnum state, LockConstraints lockPosition)
    {
        Available = available;
        State = state;
        this.lockPosition = lockPosition;
    }

    public LockAvailable.LockAvailableEnum Available {
        get {
            return _available;
        }
        set {
            if (_available != value)
            {
                _available = value;
                if (OnAvailableChanged != null)
                {
                    OnAvailableChanged(value);
                }
            }
        }
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