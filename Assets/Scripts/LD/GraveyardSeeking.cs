using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardSeeking : MonoBehaviour
{
  

    void OnTriggerEnter(Collider playerCollider)
    {
        

        if (GameObject.Find("Item_WaterCanteen").GetComponent<waterCanteenDrug>().isSeekingGraveyard == true)
        {
            GetComponent<AudioSource>().Play();
            GameObject.Find("Item_WaterCanteen").GetComponent<waterCanteenDrug>().isSeekingGraveyard = false;
            print("Everything seems different.");
            GameObject.Find("Camera").GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;

            
           



        }
    }
}
