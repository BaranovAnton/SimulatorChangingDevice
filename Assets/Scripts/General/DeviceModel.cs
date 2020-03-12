/// <summary>
/// Base class for all device models
/// </summary>
public abstract class DeviceModel
{
    // draft, are not used yet
    private int deviceID;
    public int DeviceID { get => deviceID; set => deviceID = value; }

    // draft, are not used yet
    // if device available - user can interaction with this device
    public delegate void AvailableEvent(LockAvailable.LockAvailableEnum available);
    public event AvailableEvent OnAvailableChanged;

    private LockAvailable.LockAvailableEnum _available;

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
}