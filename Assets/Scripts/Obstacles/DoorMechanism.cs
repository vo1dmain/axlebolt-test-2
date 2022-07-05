using System;

using UnityEngine;

public class DoorMechanism : MonoBehaviour
{
    [SerializeField]
    private TriggerZone[] _triggers;

    [SerializeField]
    private Door _door;

    [SerializeField]
    private MechanismMode _mode;



    #region Private methods

    private void OnButtonToggled()
    {
        switch (_mode)
        {
            case MechanismMode.AnyTrigger:
                OnAnyButtonMode();
                break;
            case MechanismMode.AllTriggers:
                OnAllButtonsMode();
                break;
            default:
                throw new NotImplementedException();
        }
    }

    private void OnAnyButtonMode()
    {
        bool isAnyTriggered = false;
        foreach (TriggerZone button in _triggers)
        {
            isAnyTriggered |= button.IsTriggered;
        }
        ToggleDoorState(isAnyTriggered);
    }

    private void OnAllButtonsMode()
    {
        bool areAllTriggered = true;
        foreach (TriggerZone button in _triggers)
        {
            areAllTriggered &= button.IsTriggered;
        }

        ToggleDoorState(areAllTriggered);
    }

    private void ToggleDoorState(bool shouldBeOpen)
    {
        if (shouldBeOpen && !_door.IsOpen) _door.Open();
        else if (!shouldBeOpen && _door.IsOpen) _door.Close();
    }

    #endregion



    #region Unity messages

    private void Awake()
    {
        foreach (TriggerZone button in _triggers)
        {
            button.OnToggle += OnButtonToggled;
        }
    }

    private void OnDestroy()
    {
        foreach (TriggerZone button in _triggers)
        {
            button.OnToggle -= OnButtonToggled;
        }
    }

    #endregion



    private enum MechanismMode : byte
    {
        AnyTrigger,
        AllTriggers
    }
}
