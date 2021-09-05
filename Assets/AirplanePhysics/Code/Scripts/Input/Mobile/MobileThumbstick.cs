using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WheelApps {
    public class MobileThumbstick : MonoBehaviour {
        #region Variables
        [Header("Thumbstick Properties")]
        public bool useMouse = true;
        public RectTransform knob;

        private RectTransform bounds;
        private Vector2 finalDelta;
        #endregion



        #region Builtin Methods

        private void Start() {
            bounds = GetComponent<RectTransform>();
        }


        private void Update() {
            if (bounds && knob) HandleThumbstick();
        }
        #endregion



        #region Custom Methods
        private void HandleThumbstick() {
            
        }
        #endregion
    }
}