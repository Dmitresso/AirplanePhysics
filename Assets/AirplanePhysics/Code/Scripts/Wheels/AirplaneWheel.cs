using System;
using UnityEngine;

namespace WheelApps {
    [RequireComponent(typeof(WheelCollider))]
    public class AirplaneWheel : MonoBehaviour {
        #region Variables
        private WheelCollider collider;

        #endregion



        #region Builtin Methods

        private void Start() {
            collider = GetComponent<WheelCollider>();
        }

        #endregion



        #region Custom Methods
        public void Init() {
            if (collider) collider.motorTorque = 0.0000001f;
        }
        #endregion
    }
}