using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour        //PROTOTYPE VERSION (BASIC)
{
    [SerializeField] Vector3 target; //Maybe use Transform instead ? For LD purpose
    [SerializeField] Transform needle;

    // Start is called before the first frame update
    void Start()
    {
        CheckIntegrity();
    }

    // Update is called once per frame
    void Update()
    {
        needle.LookAt(target, transform.up);
    }

    public void SetNorth(Vector3 newTarget) //To be used by GameManager to init the compass AND by disruptive systems
    {
        target = newTarget;
    }

    private void CheckIntegrity()
    {
        if (!needle)
            Debug.LogError("Needle not set");
        if (target == Vector3.zero)
            Debug.LogError("North position is zero");

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(target,new Vector3(1,20,1));
    }
}
