using System.Collections.Generic;
using UnityEngine;


namespace WheelApps {
    public class AirplaneCollisions : MonoBehaviour {
        #region Variables
        public List<Vector3> hitPoints = new List<Vector3>();
        public List<Vector3> hitNormals = new List<Vector3>();
        #endregion


        
        #region Builtin Methods
        private void OnCollisionEnter(Collision collision) {
            foreach (var cp in collision.contacts) {
                hitPoints.Add(cp.point);
                hitNormals.Add(cp.normal);
            }
        }

        
        private void OnDrawGizmos() {
            if (hitPoints.Count > 0) {
                for (var i = 0; i < hitPoints.Count; i++) {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawSphere(hitPoints[i], 0.1f);
                    
                    Gizmos.color = Color.green;
                    Gizmos.DrawRay(hitPoints[i], hitNormals[i]);
                }
            }
        }
        #endregion
    }
}