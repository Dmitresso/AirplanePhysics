using UnityEngine;

namespace WheelApps {
    [CreateAssetMenu(menuName = "WheelApps/Create Airplane Preset")]
    public class AirplanePreset : ScriptableObject {
        #region Controller Properties
        [Header("Controller Properties")]
        public Vector3 comPosition;
        public float airplaneWeight;
        

        #endregion
    }
}