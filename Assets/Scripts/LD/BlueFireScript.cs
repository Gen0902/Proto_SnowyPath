﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFireScript : MonoBehaviour
{
    public ParticleSystem ps;
    public bool moduleEnabled = true;

    void Start()
    {
        ps = gameObject.transform.GetComponent<ParticleSystem>();

    }

    void OnTriggerEnter(Collider playerCollider)
    {
        var emission = ps.emission;

        


            if (emission.enabled == false)
            {
                gameObject.transform.GetChild(0).GetComponent<Light>().enabled = true;
                emission.enabled = moduleEnabled;
                GameObject.Find("coffin_Lid").transform.position += new Vector3(2.0f, -0.9f, 0f);
        }



        
    }
}
