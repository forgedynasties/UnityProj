using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform bike;
    public Vector3 offset;
    public Vector3[] cameras;
    private int activeCamera;
    // Start is called before the first frame update
    void Start()
    {

        activeCamera = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (activeCamera < cameras.Length - 1)
                activeCamera++;
            else
                activeCamera=0;
        }
        transform.position = cameras[activeCamera] + bike.transform.position;



    }
}
