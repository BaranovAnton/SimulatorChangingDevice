public abstract class DeviceModel
{
    private int deviceID;
    public int DeviceID { get => deviceID; set => deviceID = value; }

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