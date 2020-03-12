using UnityEngine;

/// <summary>
/// Button class controller: device logic and connection model-view
/// </summary>
public class ButtonController : DeviceController
{
    public int id;
    public Material pressedMaterial, releasedMaterial;

    public ButtonModel buttonModel { get; private set; }
    public ButtonView buttonView { get; private set; }

    public override event ModelStateEvent OnModelStateChanged;

    private Animator buttonAnimator;

    void Start()
    {
        CreateModelAndView();
        buttonAnimator = GetComponent<Animator>();
    }

    private void CreateModelAndView()
    {
        buttonModel = new ButtonModel(id, LockAvailable.LockAvailableEnum.disable, ButtonStates.ButtonStateEnum.released);
        deviceModel = buttonModel;
        buttonModel.OnStateChanged += ButtonStateChanged;
        buttonView = GetComponentInChildren<ButtonView>();
    }

    private void OnMouseUp()
    {
        //if (buttonModel.Available == LockAvailable.LockAvailableEnum.enamble)
        //{
            switch (buttonModel.State)
            {
                case ButtonStates.ButtonStateEnum.pressed:
                    buttonModel.State = ButtonStates.ButtonStateEnum.released;
                    buttonAnimator.SetTrigger("Pressed");
                    break;
                case ButtonStates.ButtonStateEnum.released:
                    buttonModel.State = ButtonStates.ButtonStateEnum.pressed;
                    buttonAnimator.SetTrigger("Pressed");
                    break;
                default:
                    break;
            }
        //}
    }

    private void ButtonStateChanged(ButtonStates.ButtonStateEnum state)
    {
        switch (state)
        {
            case ButtonStates.ButtonStateEnum.pressed:
                buttonView.SetMaterial(pressedMaterial);
                break;
            case ButtonStates.ButtonStateEnum.released:
                buttonView.SetMaterial(releasedMaterial);
                break;
            default:
                break;
        }

        if (OnModelStateChanged != null)
        {
            OnModelStateChanged(buttonModel);
        }
    }
}