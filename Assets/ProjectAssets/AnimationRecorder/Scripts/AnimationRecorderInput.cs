using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sahan.AnimatorRecorder
{
    public class AnimationRecorderInput : MonoBehaviour
    {
        [SerializeField] private InputActionReference startAction;
        [SerializeField] private InputActionReference endAction;
        private void Start()
        {
            startAction.action.performed += OnRecordStarted;
            endAction.action.performed += OnRecordEnd;
        }

        private void OnDestroy()
        {
            startAction.action.performed -= OnRecordStarted;
            endAction.action.performed -= OnRecordEnd;
        }

        private void OnRecordStarted(InputAction.CallbackContext callbackContext)
        {
            AnimationRecorder.Instance.StartRecording();
        }
        
        private void OnRecordEnd(InputAction.CallbackContext callbackContext)
        {
            AnimationRecorder.Instance.SaveRecording();
        }
    }
}
