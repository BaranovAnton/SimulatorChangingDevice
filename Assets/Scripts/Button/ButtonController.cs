using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Material pressedMaterial, releasedMaterial;
    public LockConstraints.LockAxis lockAxe;
    public Vector2 lockAxeValue;

    public ButtonModel buttonModel { get; private set; }
    public ButtonView buttonView { get; private set; }

    void Start()
    {
        CreateModelAndView();
    }

    private void CreateModelAndView()
    {
        buttonModel = new ButtonModel(LockAvailable.LockAvailableEnum.disable, ButtonStates.ButtonStateEnum.released);
        buttonModel.OnStateChanged += ButtonStateChanged;
        buttonView = GetComponentInChildren<ButtonView>();
    }

    private void OnMouseUp()
    {
        /*if (buttonModel.Available == LockAvailable.LockAvailableEnum.enamble)
        {*/
            switch (buttonModel.State)
            {
                case ButtonStates.ButtonStateEnum.pressed:
                    buttonModel.State = ButtonStates.ButtonStateEnum.released;
                    // play animation
                    break;
                case ButtonStates.ButtonStateEnum.released:
                    buttonModel.State = ButtonStates.ButtonStateEnum.pressed;
                    // play animation
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
    }
}