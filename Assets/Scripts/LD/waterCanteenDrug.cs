﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class waterCanteenDrug : MonoBehaviour
{
    bool hasBeenDrunken = false;

    void OnTriggerEnter(Collider playerCollider)
    {
        
        if (hasBeenDrunken == false)
        {
            GetComponent<AudioSource>().Play();
            print("Everything seems different.");

            GetComponent<MeshRenderer>().enabled = false;
            hasBeenDrunken = true;
            GameObject.Find("Camera").GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;

           
        }
    }
}
