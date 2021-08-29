using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WheelApps {
    public class AirplaneUIController : MonoBehaviour {
        #region Variables
        public List<IAirplaneUI> instruments = new List<IAirplaneUI>();

        #endregion



        #region Builtin Methods
        private void Start() {
            instruments = GetComponentsInChildren<IAirplaneUI>().ToList();
        }

        private void Update() {
            if (instruments.Count <= 0) return;
            foreach (var instrument in instruments) instrument.HandleAirplaneUI();
        }

        #endregion



        #region Custom Methods

        #endregion
    }
}