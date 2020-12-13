using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class waterCanteenDrug : MonoBehaviour
{
    bool hasBeenDrunk = false;

    void OnTriggerEnter(Collider playerCollider)
    {
        
        if (hasBeenDrunk == false)
        {
            GetComponent<AudioSource>().Play();
            print("Everything seems different.");

            GetComponent<MeshRenderer>().enabled = false;
            hasBeenDrunk = true;
        }
    }
}
