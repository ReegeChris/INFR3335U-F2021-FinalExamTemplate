
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//Code Referenced from Steven's Lab 7:

public class CameraJoystick : MonoBehaviour
{
    public CinemachineFreeLook camFreeLook;
    public Joystick camStick;
    protected float CameraAngle;
    protected float CameraAngleSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        CameraAngle += camStick.Horizontal * CameraAngleSpeed;

        //Set up cinemachine free look camera to be controlled by the joysticks horizontal
        camFreeLook.m_XAxis.Value = camStick.Horizontal * CameraAngleSpeed;

    }
}
