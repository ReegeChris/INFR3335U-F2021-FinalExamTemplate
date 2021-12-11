using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;

    //Camera Movement Variables
    protected float CameraAngle;
    protected float CameraAngleSpeed = 2f;

    //Cinemachine variables
    public CinemachineFreeLook ThirdPersonCam;

    public float speed = 3f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //Variables that will instatiate each player's camera and movement joystick
    public Joystick moveStick;
    public Joystick camStick;


   // public PhotonView view;



    // Start is called before the first frame update
    void Start()
    {
        controller.GetComponent<CharacterController>();
        ThirdPersonCam.GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        CameraControls();

    }

    //Function to control player Movement and Camera Rotation
    public void Movement()

    {

        float horizontal = moveStick.Horizontal;
        float vertical = moveStick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            //Move rotation 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //Angle at which the player rotates
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //Transform used for rotating
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }


    }

    //Camera controls from camera joystick has been added to this class.
    public void CameraControls()
    {
        //CameraAngle is equal to the horizontal input from the camera joystick
        //After attaching the camera joystick to the player, the player can control the camera by moving the joystick
        CameraAngle += camStick.Horizontal * CameraAngleSpeed;

        //Calculations to determine the position of the camera and the angle.
        cam.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 3.5f, -9.4f);
        cam.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - cam.position, Vector3.up);

    }

}
