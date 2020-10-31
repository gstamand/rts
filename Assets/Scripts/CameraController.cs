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
        Vector3 pos = transform.position;
        pos.z += panSpeed * Time.deltaTime;
        transform.position = pos;
    }
    public void MoveCameraBackward()
    {
        Vector3 pos = transform.position;
        pos.z -= panSpeed * Time.deltaTime;
        transform.position = pos;
    }
    public void MoveCameraLeft()
    {
        Vector3 pos = transform.position;
        pos.x -= panSpeed * Time.deltaTime;
        transform.position = pos;
    }
    public void MoveCameraRight()
    {
        Vector3 pos = transform.position;
        pos.x += panSpeed * Time.deltaTime;
        transform.position = pos;
    }

}
