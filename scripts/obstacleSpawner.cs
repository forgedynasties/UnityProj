using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    [SerializeField] private bool lane;
    [SerializeField] private float[] lanes;
    private float distance;
    [SerializeField] private GameObject bumper;
    [SerializeField] private float minDistance, maxDistance;
    [SerializeField] private bool bumperFlag;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        distance = Random.Range(minDistance, maxDistance);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "bike")
        {
            transform.position += Vector3.right * (-distance);
            if (!lane) { 
                
            transform.position = new Vector3(transform.position.x, startPosition.y, startPosition.z);
            
            }
            else
            {
                
                transform.position = new Vector3(transform.position.x, startPosition.y, lanes[(int)Mathf.Floor(Random.Range(0, lanes.Length - 0.1f))]);
            }
            transform.rotation = startRotation;
            if(bumperFlag)
            GetComponent<CarMovement>().setNewSpeed();
            if(bumperFlag)
                bumper.transform.position += Vector3.right * (-Random.Range(0, 10));
            
        }
        
    }

    
}
