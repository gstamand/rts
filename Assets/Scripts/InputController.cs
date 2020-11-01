using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    public SelectionController selectionController;
    public AbilityController abilityController;
    public CameraController cameraController;

    public float panBorderThickness = 10f;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("MOVE");
            selectionController.MoveSelectedUnits();
            abilityController.CancelQueuedAbility();
        }
    }
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("OnSelectPerformed");
            if (abilityController.isAbilityQueued)
            {
                abilityController.CastQueuedAbility();
            }
            else
            {
                selectionController.SelectClick();
            }

        }
    }
    public void OnSelectHold(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("OnSelectHoldPerformed");
            selectionController.StartSelectionBox();
        }
        if (context.canceled)
        {
            Debug.Log("OnSelectHoldReleased");
            selectionController.ReleaseSelectionBox();
        }
    }
    public void OnAction1(InputAction.CallbackContext context)
    {
        QueueAction(context, AbilityController.Abilities.Ability1);
    }
    public void OnAction2(InputAction.CallbackContext context)
    {
        QueueAction(context, AbilityController.Abilities.Ability2);
    }
    public void OnAction3(InputAction.CallbackContext context)
    {
        QueueAction(context, AbilityController.Abilities.Ability3);
    }
    public void OnAction4(InputAction.CallbackContext context)
    {
        QueueAction(context, AbilityController.Abilities.Ability4);
    }

    private void QueueAction(InputAction.CallbackContext context, AbilityController.Abilities ability)
    {
        if (context.performed)
        {
            Debug.Log(ability);
            if (selectionController.activeUnit != null)
            {
                if (selectionController.activeUnit.delayRemaining < 0) abilityController.QueueAbility(ability);
            }
        }
    }

    void Update()
    {
        CheckMousePosition();
    }

    void CheckMousePosition()
    {
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            cameraController.MoveCameraForward();
        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            cameraController.MoveCameraBackward();
        }
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            cameraController.MoveCameraRight();
        }
        if (Input.mousePosition.x <= panBorderThickness)
        {
            cameraController.MoveCameraLeft();
        }
    }
    
}
