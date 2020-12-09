using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour        //PROTOTYPE VERSION (BASIC)
{
    [SerializeField] Transform target; //Maybe use Transform instead ? For LD purpose
    [SerializeField] Transform needle;

    // Start is called before the first frame update
    void Start()
    {
        CheckIntegrity();
    }

    // Update is called once per frame
    void Update()
    {
        needle.LookAt(target);
        needle.localEulerAngles = new Vector3(0, needle.localEulerAngles.y, 0);
    }

    private void CheckIntegrity()
    {
        if (!needle)
            Debug.LogError("Needle not set");
        if (!target)
        {
            GameObject northGO = GameObject.FindGameObjectWithTag("NorthPole");
            if (northGO)
                target = northGO.transform;
            else
                Debug.LogError("Can't find North Pole");
        }

    }
}
