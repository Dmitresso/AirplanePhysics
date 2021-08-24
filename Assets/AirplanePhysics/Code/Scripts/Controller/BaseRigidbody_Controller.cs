﻿using UnityEngine;

namespace WheelApps {
    [RequireComponent(typeof(Rigidbody),
                     typeof(AudioSource))]
    public class BaseRigidbody_Controller : MonoBehaviour {
        #region Variables
        private Rigidbody rb;
        private AudioSource audioSource;

        #endregion

        
        
        #region Builtin Methods
        private void Start() {
            rb = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();
            if (audioSource) audioSource.playOnAwake = false;
        }


        private void FixedUpdate() {
            if (rb) HandlePhysics();
        }

        #endregion
        
        
        
        #region Custom Methods
        protected virtual void HandlePhysics() {
            
        }
        #endregion
    }
}