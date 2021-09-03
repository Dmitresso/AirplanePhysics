using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WheelApps {
    public class Track : MonoBehaviour {
        #region Variables
        [Header("Track Properties")]
        public List<Gate> gates = new List<Gate>();

        private int currentGateId;
        #endregion



        #region Builtin Methods
        private void Start() {
            FindGates();
            InitializeGates();

            currentGateId = 0;
        }

        #endregion



        #region Custom Methods
        private void SelectNextGate() {
            
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
