using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WheelApps {
    public class Gate : MonoBehaviour {
        #region Variables
        [Header("Gate Properties")]
        public bool reverseDirection;
        public bool isActive;

        [Header("UI Properties")]
        public Image arrowImage;

        [Header("Gate Events")]
        public UnityEvent OnClearedGate = new UnityEvent();
        public UnityEvent OnFailedGate = new UnityEvent();
        
        private Vector3 gateDirection;

        #endregion



        #region Builtin Methods
        private void Start() {

        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(Tags.Player)) {
                
            }
        }

        private void OnDrawGizmos() {
            GetGateDirection();
            
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + gateDirection * 6f);
            Gizmos.DrawSphere(transform.position + gateDirection * 6f, 1f);
        }

        #endregion



        #region Custom Methods
        public void ActivateGate() {
            
        }

        public void DeactivateGate() {
            
        }

        public void CheckDirection(Vector3 direction) {
            var dot = Vector3.Dot(gateDirection, direction);
            if (dot > 0.25f) {
                OnClearedGate?.Invoke();
            }
            else OnFailedGate?.Invoke();
        }

        private void GetGateDirection() {
            gateDirection = transform.forward;
            if (reverseDirection) gateDirection = -gateDirection;
        }
        #endregion
    }
}
