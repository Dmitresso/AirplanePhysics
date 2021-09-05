using UnityEngine;
using UnityEngine.Events;


namespace WheelApps{
    public class AirplaneEngineCutoff : MonoBehaviour {
        #region Variables
        [Header("Engine Cutoff Properties")]
        public KeyCode cutoffKey = KeyCode.O;
        public UnityEvent OnEngineCutoff = new UnityEvent();
        #endregion



        #region Builtin Methods
        private void Update() {
            if (Input.GetKeyDown(cutoffKey)) OnEngineCutoff?.Invoke();
        }
        #endregion



        #region Custom Methods
        private void HandleEngineCutoff() {
            
        }
        #endregion
    }
}