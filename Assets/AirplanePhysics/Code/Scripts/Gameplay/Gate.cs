using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace WheelApps {
    [Serializable] public class FloatEvent : UnityEvent<float> { }
    
    
    public class Gate : MonoBehaviour {
        #region Variables
        [Header("Gate Properties")]
        public bool reverseDirection;
        
        [Header("UI Properties")]
        public Image arrowImage;

        [Header("Gate Events")]
        public FloatEvent OnClearedGate = new FloatEvent();
        public UnityEvent OnFailedGate = new UnityEvent();
        
        private Vector3 gateDirection;
        public bool isActive;
        public bool isCleared;
        #endregion



        #region Builtin Methods
        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag(Tags.Player) && !isCleared) {
                var distance = Vector3.Distance(other.transform.position, transform.position);
                var distancePercentage = distance / transform.localScale.x;
                CheckDirection(other.transform.forward, distancePercentage);
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
            isActive = true;

            if (arrowImage) arrowImage.enabled = true;
        }

        
        public void DeactivateGate() {
            isActive = false;
            isCleared = false;

            if (arrowImage) arrowImage.enabled = false;
        }

        
        public void CheckDirection(Vector3 direction, float distancePercentage) {
            var dot = Vector3.Dot(gateDirection, direction);
            if (dot > 0.25f) {
                OnClearedGate?.Invoke(distancePercentage );
                isCleared = true;
                DeactivateGate();
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