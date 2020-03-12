/// <summary>
/// Class for Fuse model
/// </summary>
public class FuseModel : DeviceModel
{
    public delegate void PositionEvent(PositionStates.PositionStateEnum place);
    public event PositionEvent OnPositionChanged;

    public delegate void WorkingEvent(WorkingStates.WorkingStateEnum state);
    public event WorkingEvent OnWorkingChanged;

    private PositionStates.PositionStateEnum _place;
    private WorkingStates.WorkingStateEnum _state;

    // fuse model constructor
    public FuseModel(int id, LockAvailable.LockAvailableEnum available, PositionStates.PositionStateEnum place, WorkingStates.WorkingStateEnum state)
    {
        DeviceID = id;
        Available = available;
        Place = place;
        State = state;
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