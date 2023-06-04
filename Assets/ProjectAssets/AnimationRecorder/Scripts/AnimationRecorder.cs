using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Sahan.AnimatorRecorder
{
    public class AnimationRecorder : MonoBehaviour
    {
        #region Singleton

        public static AnimationRecorder Instance { get; private set; }
        
        private void Awake() 
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            } 
        }

        #endregion
        
        [SerializeField] private GameObject gameObjectToRecord;
        [SerializeField] private AnimationClip animationClip;
        [SerializeField] private Animator previewAnimator;
        
        private GameObjectRecorder m_Recorder;
        private bool isRecording = false;
        
        private void Start()
        {
            m_Recorder = new GameObjectRecorder(gameObjectToRecord);
            m_Recorder.BindComponentsOfType<Transform>(gameObjectToRecord, true);
        }

        public void StartRecording()
        {
            isRecording = true;
        }

        public void SaveRecording()
        {
            if (animationClip == null)
            {
                return;
            }

            if (m_Recorder.isRecording)
            {
                m_Recorder.SaveToClip(animationClip);
            }

            isRecording = false;
            
            previewAnimator.Rebind();
            previewAnimator.Update(0f);
        }

        private void LateUpdate()
        {
            if (isRecording)
            {
                if (animationClip == null)
                {
                    return;
                }
                m_Recorder.TakeSnapshot(Time.deltaTime);
            }
        }

        private void OnDisable()
        {
            if (animationClip == null)
            {
                return;
            }

            if (m_Recorder.isRecording)
            {
                m_Recorder.SaveToClip(animationClip);
            }
        }
    }
}
