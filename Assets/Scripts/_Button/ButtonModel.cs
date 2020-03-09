/// <summary>
/// Класс модели кнопки
/// </summary>
public class ButtonModel
{
    public delegate void AvailableEvent(LockAvailable.LockAvailableEnum available);
    public event AvailableEvent OnAvailableChanged;

    public delegate void StateEvent(ButtonStates.ButtonStateEnum state);
    public event StateEvent OnStateChanged;

    private LockAvailable.LockAvailableEnum _available;     // доступно ли устройство для взаимодействия? (смены состояния)
    private ButtonStates.ButtonStateEnum _state;    // состояние устройства? открыто/закрыто

    public ButtonModel(LockAvailable.LockAvailableEnum available, ButtonStates.ButtonStateEnum state)
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
                if (OnAvailableChanged != null)
                {
                    OnAvailableChanged(value);
                }
            }
        }
    }

    public ButtonStates.ButtonStateEnum State {
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