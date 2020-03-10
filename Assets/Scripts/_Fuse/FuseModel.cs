/// <summary>
/// Class describes Fuse model
/// A fuse is an electrical safety device that operates to provide overcurrent protection of an electrical circuit
/// </summary>
public class FuseModel
{
    public delegate void AvailableEvent(LockAvailable.LockAvailableEnum available);
    public event AvailableEvent OnAvailableChanged;

    public delegate void PositionEvent(PositionStates.PositionStateEnum place);
    public event PositionEvent OnPositionChanged;

    public delegate void WorkingEvent(WorkingStates.WorkingStateEnum state);
    public event WorkingEvent OnWorkingChanged;

    private LockAvailable.LockAvailableEnum _available;
    private PositionStates.PositionStateEnum _place;
    private WorkingStates.WorkingStateEnum _state;

    public FuseModel(LockAvailable.LockAvailableEnum available, PositionStates.PositionStateEnum place, WorkingStates.WorkingStateEnum state)
    {
        Available = available;
        Place = place;
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
                if (OnAvailableChanged != null)
                {
                    OnAvailableChanged(value);
                }
            }
        }
    }

    public PositionStates.PositionStateEnum Place {
        get {
            return _place;
        }
        set {
            if (_place != value)
            {
                _place = value;
                if (OnPositionChanged != null)
                {
                    OnPositionChanged(value);
                }
            }
        }
    }

    public WorkingStates.WorkingStateEnum State {
        get {
            return _state;
        }
        set {
            if (_state != value)
            {
                _state = value;
                if (OnWorkingChanged != null)
                {
                    OnWorkingChanged(value);
                }
            }
        }
    }
}