using UnityEditor;
using UnityEngine;

namespace WheelApps {
    [CustomEditor(typeof(BaseAirplaneInput))]
    public class BaseAirplaneInputEditor : Editor {
        #region Variables
        private BaseAirplaneInput targetInput;
        #endregion

        
        #region Builtin Methods
        private void OnEnable() {
            targetInput = (BaseAirplaneInput) target;
        }


        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            
            var debugInfo = string.Empty;
            debugInfo += "Pitch: " + targetInput.Pitch + "\n";
            debugInfo += "Roll: " + targetInput.Roll + "\n";
            debugInfo += "Yaw: " + targetInput.Yaw + "\n";
            debugInfo += "Throttle: " + targetInput.Throttle + "\n";
            debugInfo += "Brake: " + targetInput.Brake + "\n";
            debugInfo += "Flaps: " + targetInput.Flaps + "\n";

            GUILayout.Space(20);
            EditorGUILayout.TextArea(debugInfo, GUILayout.Height(100));
            GUILayout.Space(20);
            
            Repaint();
        }
        #endregion
    }
}