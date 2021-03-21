using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private bool isBrake;
    private bool isHit;
    public bool userDestroyed;
    private float currentBrakeForce;
    private float currentRotateAngle;
    public float brakeForceTorque;

    [SerializeField] public float maxAngle;
    [SerializeField] public float motorTorqueForce;
    [SerializeField] private float brakeForce;
   
    public GameObject particle;

    private soundHandler sh;
 

    [SerializeField] public WheelCollider frontLeftWheelCollider;
    [SerializeField] public WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private void handleSound(float speed)
    {
       if (verticalInput==0.0f)
        {
            sh.play_idle();
        }
        if (verticalInput > 0 && speed > 0 && speed<20)
        {
            sh.play_accLow();
        }
        else if (verticalInput > 0 && speed > 20 && speed < 38)
        {
            sh.play_accMed();
        }
        else if (verticalInput > 0 && speed > 38 && speed < 100)
        {
            sh.play_accHigh();
        }
        else if (verticalInput < 0 && speed > 0 && speed < 20)
        {
            sh.play_decLow();
        }
        else if (verticalInput < 0 && speed > 20 && speed < 38)
        {
            sh.play_decMed();
        }
        else if (verticalInput < 0 && speed > 38 && speed < 100)
        {
            sh.play_decHigh();
        }
       


    }

    private void Start()
    {
        sh=GetComponent<soundHandler>();
    }
    private void Update()
    {

        float speed = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        getUserInput();
        handleSound(speed);
    }
    private void FixedUpdate()
    {
       
      

        moveCar();
        rotateCar();
        rotateTheWheels();
        brake();
    }
    private void rotateTheWheels()
    {
        rotateWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        rotateWheel(frontRightWheelCollider, frontRightWheelTransform);
        rotateWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        rotateWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }
    private void rotateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.position = position;
        wheelTransform.rotation= rotation;

    }

    private void getUserInput()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
   
    }
    private void moveCar()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorTorqueForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorTorqueForce;
        //rearLeftWheelCollider.motorTorque = verticalInput * motorTorqueForce;
        //rearRightWheelCollider.motorTorque = verticalInput * motorTorqueForce;       
    }
    private void rotateCar()
    {

        currentRotateAngle = maxAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentRotateAngle;
        frontRightWheelCollider.steerAngle = currentRotateAngle;
    }

    private void brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isBrake = true;
        }
        else
        {
            isBrake = false;
        }
        if (isBrake)
        {
            frontLeftWheelCollider.brakeTorque = brakeForceTorque;
            frontRightWheelCollider.brakeTorque = brakeForceTorque;
            frontLeftWheelCollider.motorTorque = 0;
            frontRightWheelCollider.motorTorque = 0;
        }
        else
        {
            frontLeftWheelCollider.brakeTorque = 0;
            frontRightWheelCollider.brakeTorque = 0;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = collision.gameObject.GetComponent<Rigidbody>().velocity;
        float speed = Vector3.Magnitude(velocity);
        if (speed > 12.0f)
        {
          Instantiate(particle, transform.position, transform.rotation);
        }
        
    }
}
