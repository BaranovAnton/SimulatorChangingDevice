using UnityEngine;

public class LatchModel
{
    public delegate void AvailableEvent(LockAvailable.LockAvailableEnum available);
    public event AvailableEvent OnAvailableChanged;

    public delegate void StateEvent(LockStates.LockStateEnum state);
    public event StateEvent OnStateChanged;

    private LockAvailable.LockAvailableEnum _available;     // доступно ли устройство для взаимодействия? (смены состояния)
    private LockStates.LockStateEnum _state;    // состояние устройства? открыто/закрыто

    //private float lockedPosition, unlockedPosition;

    public LatchModel(LockAvailable.LockAvailableEnum available, LockStates.LockStateEnum state)
    {
        Available = available;
        State = state;
    }

    public LockAvailable.LockAvailableEnum Available {
        get {
            return _available;
        }
        set {
            if (_available != value)
            {
                _available = value;
                if (OnStateChanged != null)
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