using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


namespace WheelApps {
    public class Track : MonoBehaviour {
        #region Variables
        [Header("Track Properties")]
        public List<Gate> gates = new List<Gate>();

        [Header("Track Events")]
        public UnityEvent OnCompletedTrack = new UnityEvent();
        
        private int currentGateId;
        #endregion



        #region Builtin Methods
        private void Start() {
            FindGates();
            InitializeGates();

            currentGateId = 0;
            StartTrack();
        }

        private void OnDrawGizmos() {
            if (gates.Count <= 0) return;
            for (var i = 0; i < gates.Count; i++) {
                if (i + 1 == gates.Count) break;
                Gizmos.color = new Color(0.5f, 0.2f, 0.6f, 0.5f);
                Gizmos.DrawLine(gates[i].transform.position, gates[i + 1].transform.position);
            }
        }
        #endregion



        #region Custom Methods
        public void StartTrack() {
            if (gates.Count <= 0) return;
            gates[currentGateId].ActivateGate();
        }
        
        
        private void SelectNextGate() {
            currentGateId++;
            if (currentGateId == gates.Count) OnCompletedTrack?.Invoke();
            gates[currentGateId].ActivateGate();
        }
        
        
        private void FindGates() {
            gates.Clear(); 
            gates = GetComponentsInChildren<Gate>().ToList();
        }

        
        private void InitializeGates() {
            if (gates.Count <= 0) return; 
            foreach (var gate in gates) {
                gate.DeactivateGate();
                gate.OnClearedGate.AddListener(SelectNextGate);
            }
        }
        #endregion
    }
}
