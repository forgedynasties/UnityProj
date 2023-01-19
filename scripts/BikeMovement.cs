using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float force;
    private bool throttle;
    private bool brake;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        throttle = false;
        brake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(-force * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(force * Time.deltaTime, 0, 0);

        if (throttle)
        {
            rb.AddForce(-force * Time.deltaTime, 0, 0);

        }

        if (brake)
        {
            rb.AddForce(force *2* Time.deltaTime, 0, 0);

        }
    }

    public void throttleButtonDown()
    {
        throttle = true;
    }

    public void throttleButtonUp()
    {
        throttle = false;
    }

    public void brakeButtonDown()
    {
        brake = true;
    }

    public void brakeButtonUp()
    {
        brake = false;
    }

}
