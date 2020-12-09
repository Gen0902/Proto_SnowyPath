using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour    //PROTOTYPE VERSION (BASIC)
{
    [SerializeField] Transform leftHand;
    [SerializeField] Transform rightHand;

    [SerializeField] List<PlayerTool> rightTools;
    [SerializeField] List<PlayerTool> leftTools;

    private int rightIndex = 0;

    void Start()
    {
        CheckIntegrity();
    }

    void Update()
    {
        //Two versions of swaping tools
        if (Input.GetKeyDown(KeyCode.Mouse2))
            SwitchRightTool(1);

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            SwitchRightTool(1);
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            SwitchRightTool(-1);
    }

    private void SwitchRightTool(int scroll)
    {
        if (rightTools.Count > 1)
            rightIndex += scroll;

        if (rightIndex >= rightTools.Count)
            rightIndex = -1;
        else if (rightIndex < -1)
            rightIndex = rightTools.Count - 1;

        EquipTool(rightIndex, EToolHand.Right);
    }

    private void EquipTool(int index, EToolHand toolHand)
    {
        switch (toolHand)
        {
            case EToolHand.Left:
                EnableTool(leftTools, index);
                break;
            case EToolHand.Right:
                EnableTool(rightTools, index);
                break;
            case EToolHand.Both:
                break;
            default:
                break;
        }
    }

    private void EnableTool(List<PlayerTool> tools, int enableIndex)
    {
        for (int i = 0; i < tools.Count; i++)
            tools[i].gameObject.SetActive(false);

        if (enableIndex >= 0 && enableIndex < tools.Count)
            tools[enableIndex].gameObject.SetActive(true);
    }

    private void CheckIntegrity()
    {
        if (!leftHand)
            Debug.LogError("Left hand transform is not set");
        if (!rightHand)
            Debug.LogError("Right hand transform is not set");

        if (rightTools == null)
            rightTools = new List<PlayerTool>();
        if (leftTools == null)
            leftTools = new List<PlayerTool>();
    }
}
