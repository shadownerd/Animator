using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRigMovements : MonoBehaviour
{
    [SerializeField] public Transform copyTargetHead;
    [SerializeField] public Transform ikTargetHead;
    
    [SerializeField] public Transform copyTargetLeftArm;
    [SerializeField] public Transform ikTargetLeftArm;
    
    [SerializeField] public Transform copyTargetRightArm;
    [SerializeField] public Transform ikTargetRightArm;

    private void LateUpdate()
    {
        copyTargetHead.localPosition = ikTargetHead.localPosition;
        copyTargetHead.localRotation = ikTargetHead.localRotation;
        
        copyTargetLeftArm.localPosition = ikTargetLeftArm.localPosition;
        copyTargetLeftArm.localRotation = ikTargetLeftArm.localRotation;
        
        copyTargetRightArm.localPosition = ikTargetRightArm.localPosition;
        copyTargetRightArm.localRotation = ikTargetRightArm.localRotation;
    }
}
