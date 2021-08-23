using UnityEditor;
using UnityEngine;

namespace WheelApps {
    [CustomEditor(typeof(XboxAirplane_Input))]
    public class XboxAirplaneInput_Editor : Editor {
        #region Variables
        private BaseAirplane_Input targetInput;
        #endregion

        
        #region Builtin Methods
        private void OnEnable() {
            targetInput = (XboxAirplane_Input) target;
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