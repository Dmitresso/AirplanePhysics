using UnityEngine;


namespace WheelApps {
    [CreateAssetMenu(menuName = "WheelApps/Create Airplane Preset")]
    public class AirplanePreset : ScriptableObject {
        #region Controller Properties
        [Header("Controller Properties")]
        public Vector3 comPosition;
        public float airplaneWeight;
        #endregion



        #region Characteristics Properties
        [Header("Characteristics Properties")]
        public float maxMPH = 110f;
        public float rbLerpSpeed = 0.03f;
        public float maxLiftPower = 5000f;
        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        public float dragFactor = 0.0004f;
        public float flapDragFactor = 0.0004f;
        public float pitchSpeed = 1500f;
        public float rollSpeed = 1500f;
        public float yawSpeed = 1500f;
        #endregion
    }
}