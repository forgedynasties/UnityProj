using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float carSpeed;
    [SerializeField]private float speedFac;
    [SerializeField] private GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        carSpeed = Random.Range(0.5f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.position += Vector3.right * (-carSpeed);*/
        car.GetComponent<Rigidbody>().velocity = Vector3.right * (-carSpeed * speedFac);
       

    }

    public void setNewSpeed()
    {
        carSpeed = Random.Range(0.01f, 0.1f);
        
    }
}
