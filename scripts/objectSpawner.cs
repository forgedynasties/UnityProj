using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    [SerializeField] private int objectCount;

    private void Update()
    {
       
    }
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.tag == "bike")
        {
            transform.position += new Vector3(-(GetComponent<MeshRenderer>().bounds.extents.x) * 2 * objectCount, 0, 0);
           
            Debug.Log("yes");
        }
    }

    
}

