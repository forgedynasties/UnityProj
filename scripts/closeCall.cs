using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeCall : MonoBehaviour
{
    public GameObject slomoButton;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "car")
        {
            Debug.Log("close call");
            slomoButton.GetComponent<SlomoButton>().incSlomo();
        }
    }
}
