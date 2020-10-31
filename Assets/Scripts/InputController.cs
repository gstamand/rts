using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputController : MonoBehaviour
{


    public SelectionController selectionController;
    public CameraController cameraController;

    public float panBorderThickness = 10f;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selectionController.MoveSelectedUnits();
        }
        if (Input.GetMouseButtonDown(0))
        {
            selectionController.StartSelectionBox();
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectionController.ReleaseSelectionBox();
        }
        if (Input.GetMouseButton(0))
        {
            selectionController.UpdateSelectionBox(Input.mousePosition);
        }
        if(Input.mousePosition.y >= Screen.height - panBorderThickness)
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
