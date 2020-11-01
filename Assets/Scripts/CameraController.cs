using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 20f;

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

    }
    public void MoveCameraForward()
    {
        Forward();
        Right();
    }
    public void MoveCameraBackward()
    {
        Backward();
        Left();
    }
    public void MoveCameraLeft()
    {
        Forward();
        Left();
    }
    public void MoveCameraRight()
    {
        Backward();
        Right();
    }
    private void Forward()
    {
        Vector3 pos = transform.position;
        pos.z += panSpeed * Time.deltaTime;
        transform.position = pos;
    }
    private void Backward()
    {
        Vector3 pos = transform.position;
        pos.z -= panSpeed * Time.deltaTime;
        transform.position = pos;
    }
    private void Left()
    {
        Vector3 pos = transform.position;
        pos.x -= panSpeed * Time.deltaTime;
        transform.position = pos;
    }
    private void Right()
    {
        Vector3 pos = transform.position;
        pos.x += panSpeed * Time.deltaTime;
        transform.position = pos;
    }

}
