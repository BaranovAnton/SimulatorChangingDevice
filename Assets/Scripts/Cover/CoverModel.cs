/// <summary>
/// Класс модели крышки
/// </summary>
public class CoverModel
{
    public delegate void AvailableEvent(LockAvailable.LockAvailableEnum available);
    public event AvailableEvent OnAvailableChanged;

    public delegate void StateEvent(OpenStates.OpenStateEnum state);
    public event StateEvent OnStateChanged;

    private LockAvailable.LockAvailableEnum _available;     // доступна ли крышка для взаимодействия? (открытия/закрытия)
    private OpenStates.OpenStateEnum _state;    // состояние крышки? открыта/закрыта

    private LockConstraints openPosition;  // позиция при которой крышка закрыта/открыта (ось и значение)
    private float lockDelta = 0.1f;
    public float LockDelta { get => lockDelta; set => lockDelta = value; }

    public CoverModel(LockAvailable.LockAvailableEnum available, OpenStates.OpenStateEnum state, LockConstraints openPosition)
    {
        Available = available;
        State = state;
        this.openPosition = openPosition;
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