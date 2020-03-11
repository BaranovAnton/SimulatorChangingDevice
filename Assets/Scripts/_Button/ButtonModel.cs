/// <summary>
/// Класс модели кнопки
/// </summary>
public class ButtonModel : DeviceModel
{
    public delegate void StateEvent(ButtonStates.ButtonStateEnum state);
    public event StateEvent OnStateChanged;

    private ButtonStates.ButtonStateEnum _state;    // состояние устройства? открыто/закрыто

    public ButtonModel(int id, LockAvailable.LockAvailableEnum available, ButtonStates.ButtonStateEnum state)
    {
        DeviceID = id;
        Available = available;
        State = state;
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