
using UnityEngine;

public class BikeController : MonoBehaviour
{
    public Transform handlebar; // drag the handlebar transform here in the inspector
    public float rotationSpeed = 1f; // the speed at which the handlebar rotates
    public Transform bike;
    private Quaternion initialRotation; // store the initial rotation of the handlebar
    private Quaternion targetRotation; // the target rotation of the handlebar
    private Quaternion initialRotationBike; // store the initial rotation of the handlebar
    private Quaternion targetRotationBike; // the target rotation of the handlebar
    public Rigidbody rb;
    public float sideForce;
    private bool engineOn;
    public AudioSource engineStart;

    void Start()
    {
        // store the initial rotation of the handlebar
        initialRotation = handlebar.localRotation;
        targetRotation = initialRotation; // set the target rotation to the initial rotation
                                          // store the initial rotation of the handlebar
        initialRotationBike = bike.localRotation;
        targetRotationBike = initialRotationBike; // set the target rotation to the initial rotation
        engineOn = false;
        GetComponent<AudioSource>().enabled = false;
        GetComponent<EngineSound>().enabled = false;
        GetComponent<BikeMovement>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (engineOn)
            {
                engineOn = false;
                GetComponent<AudioSource>().enabled = false;
                GetComponent<EngineSound>().enabled = false;
                GetComponent<BikeMovement>().enabled = false;

            }
                
            else
            {
                engineOn = true;
                GetComponent<AudioSource>().enabled = true;
                GetComponent<EngineSound>().enabled = true;
                GetComponent<BikeMovement>().enabled = true;
                engineStart.Play();


            }

        }

        if (engineOn)
        {
            

            if (Input.GetKey(KeyCode.A))
                rb.AddForce(0, 0, -sideForce * Time.unscaledDeltaTime, ForceMode.VelocityChange);


            if (Input.GetKey(KeyCode.D))
                rb.AddForce(0, 0, sideForce * Time.unscaledDeltaTime, ForceMode.VelocityChange);
        }
       if(Input.GetKeyDown(KeyCode.W))
            GetComponent<AudioSource>().enabled = true;
        if (Input.GetKeyUp(KeyCode.W))
            GetComponent<AudioSource>().enabled = false;
        if (Input.GetKeyDown(KeyCode.A))
        {
            // set target rotation to 30 degrees around the z-axis
            Quaternion rotation = Quaternion.AngleAxis(-30f, Vector3.up);
            targetRotation = handlebar.localRotation * rotation;
            Quaternion rotationBike = Quaternion.AngleAxis(-30f, Vector3.right);
            targetRotationBike = bike.localRotation * rotationBike;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // set target rotation to 30 degrees around the z-axis
            Quaternion rotation = Quaternion.AngleAxis(30f, Vector3.up);
            targetRotation = handlebar.localRotation * rotation;
            Quaternion rotationBike = Quaternion.AngleAxis(30f, Vector3.right);
            targetRotationBike = bike.localRotation * rotationBike;

        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            // reset target rotation to initial rotation
            targetRotation = initialRotation;
            targetRotationBike = initialRotationBike;
        }
        
      


        // smoothly interpolate towards the target rotation
        handlebar.localRotation = Quaternion.Lerp(handlebar.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
        bike.localRotation = Quaternion.Lerp(bike.localRotation, targetRotationBike, Time.deltaTime * rotationSpeed);

    }

    public void steerLeftDown()
    {
        // set target rotation to 30 degrees around the z-axis
        Quaternion rotation = Quaternion.AngleAxis(-30f, Vector3.up);
        targetRotation = handlebar.localRotation * rotation;
        Quaternion rotationBike = Quaternion.AngleAxis(-30f, Vector3.right);
        targetRotationBike = bike.localRotation * rotationBike;
    }
    public void steerRightDown()
    {
        // set target rotation to 30 degrees around the z-axis
        Quaternion rotation = Quaternion.AngleAxis(30f, Vector3.up);
        targetRotation = handlebar.localRotation * rotation;
        Quaternion rotationBike = Quaternion.AngleAxis(30f, Vector3.right);
        targetRotationBike = bike.localRotation * rotationBike;
    }

    public void steerLeft()
    {
        rb.AddForce(0, 0, -sideForce * Time.unscaledDeltaTime, ForceMode.VelocityChange);

    }

    public void steerRight() {
        rb.AddForce(0, 0, sideForce * Time.unscaledDeltaTime, ForceMode.VelocityChange);

    }

    public void steerUp()
    {
        targetRotation = initialRotation;
        targetRotationBike = initialRotationBike;
    }
    public void throttle()
    {

    }

    public void brake()
    {

    }

    public void startEngine()
    {

        if (engineOn)
        {
            engineOn = false;
            GetComponent<AudioSource>().enabled = false;
            GetComponent<EngineSound>().enabled = false;
            GetComponent<BikeMovement>().enabled = false;

        }

        else
        {
            engineOn = true;
            GetComponent<AudioSource>().enabled = true;
            GetComponent<EngineSound>().enabled = true;
            GetComponent<BikeMovement>().enabled = true;
            engineStart.Play();


        }
    }


}


