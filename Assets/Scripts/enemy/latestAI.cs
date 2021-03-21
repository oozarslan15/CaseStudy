using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class latestAI : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;
    [SerializeField] private WheelCollider frontLeftWheelCollider;    

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform enemy1Transform;
    [SerializeField] private Transform enemy2Transform;
    [SerializeField] private Transform enemy3Transform;
    [SerializeField] private Transform enemy4Transform;
    [SerializeField] private Transform enemy5Transform;
    [SerializeField] private Transform enemy6Transform;
    [SerializeField] private Transform enemy7Transform;
    [SerializeField] private Transform enemy8Transform;
    [SerializeField] private Transform enemy9Transform;
    

    Vector3 direction;
    Vector3 random_location;
    public float maxAngle;
    private float distance;
    private float currentRotateAngle;

    public GameObject particle;


    public bool enemy1destroyed;
    public bool enemy2destroyed;
    public bool enemy3destroyed;
    public bool enemy4destroyed;
    public bool enemy5destroyed;
    public bool enemy6destroyed ;
    public bool enemy7destroyed ;
    public bool enemy8destroyed ;
    public bool enemy9destroyed ;
    public bool enemy10destroyed ;

    public float motorTorqueForce;
    private bool isArrived;
    private float moveInput;
    private float turnInput;
    private int player_hit;
    private int enemy_hit;
    // Front or Back .dot product
    private void chooseLocation()
    {
        //random_location = new Vector3( Random.Range(-70.0f,70.0f), 0 , Random.Range(-50.0f, 50.0f));
        int fate = Random.Range(0, 10);
        switch (fate)
        {
            case 0:
                if (!playerTransform.GetComponent<CarController>().userDestroyed)
                {
                    random_location = playerTransform.transform.position;
                    break;
                }
                else
                {
                   
                goto case 1;
                   
                }
                
                
            case 1:
                if (!enemy1destroyed)
                {
                    random_location = enemy1Transform.transform.position;
                    break;
                }
                else
                {
                    goto case 2;
                }
            
            case 2:
                if (!enemy2destroyed)
                {
                    random_location = enemy2Transform.transform.position;
                    break;
                }
                else
                {
                    goto case 3;
                }
            case 3:
                if (!enemy3destroyed)
                {
                    random_location = enemy3Transform.transform.position;
                    break;
                }
                else
                {
                    goto case 4;
                }
            case 4:
                if (!enemy4destroyed)
                {
                    random_location = enemy4Transform.transform.position;
                    break;
                }
                else
                {
                    goto case 5;
                }
            case 5:
                if(!enemy5destroyed)
                {
                    random_location = enemy5Transform.transform.position;
                    break;
                }
                else
                {
                    goto case 6;
                }
            case 6:
                if (!enemy6destroyed)
                {
                    random_location = enemy6Transform.transform.position;
                    break;
                }
                else
                {
                    goto case 7;
                }
            case 7:
                if (!enemy7destroyed)
                {
                    random_location = enemy7Transform.transform.position;
                    break;
                }
                else
                {
                    goto case 8;
                }
            case 8:
                if (!enemy8destroyed)
                {
                    random_location = enemy8Transform.transform.position;
                    break;
                }
                else
                {
                    goto case 9;
                }
            case 9:
                if (!enemy9destroyed)
                {
                    random_location = enemy9Transform.transform.position;
                    break;
                }
                else
                {
                    goto case 0;
                }
         
        }      
    }
    

    private void setInputs(float dot, float angle, float dist2target)
    {
        if (angle > 0.0f)
        {
            turnInput = -1.0f;
        }
        else if (angle < 10.0f && angle > -10.0f)
        {
            turnInput = 0.0f;
        }
        else
        {
            turnInput = 1.0f;
        }
       
       if (dot <0)
        {
            moveInput = -1.0f;
        } else
        {
            moveInput = 1.0f;
        }
    }

    private void Start()
    {
        chooseLocation();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             player_hit+= 1;
        } else
        {
            enemy_hit += 1;
        }
        if (player_hit>5)
        {
            player_hit = 0;
            chooseLocation();
        }
        if (enemy_hit>2)
        {
            enemy_hit = 0;
            chooseLocation();
        }

        Vector3 velocity = collision.gameObject.GetComponent<Rigidbody>().velocity;
        float speed = Vector3.Magnitude(velocity);
        if (speed > 20.0f)
        {
            Instantiate(particle, transform.position, transform.rotation);
        }

    }

    private void Update()
    {
       
        
        direction = (random_location - transform.position);
        distance = Vector3.Distance(random_location, transform.position);
        float dot_product = Vector3.Dot(transform.forward, direction.normalized);
        float angle = Vector3.SignedAngle(direction, transform.forward,Vector3.up);
        setInputs(dot_product, angle, distance);
      

    }

    private void FixedUpdate()
    { 
        moveCar();
        rotateCar();
        rotateTheWheels(); 
    }

 
    private void rotateCar()
    {
        currentRotateAngle = maxAngle * turnInput;
        frontLeftWheelCollider.steerAngle = currentRotateAngle;
        frontRightWheelCollider.steerAngle = currentRotateAngle;
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
        wheelTransform.rotation = rotation;

    }

    private void moveCar()
    {
        frontLeftWheelCollider.motorTorque = motorTorqueForce * moveInput;
        frontRightWheelCollider.motorTorque = motorTorqueForce * moveInput;   
    }

}
