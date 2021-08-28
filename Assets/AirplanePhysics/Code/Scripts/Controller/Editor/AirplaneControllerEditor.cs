using System;
using UnityEditor;
using UnityEngine;

namespace WheelApps {
    [CustomEditor(typeof(AirplaneController))]
    public class AirplaneControllerEditor : Editor {
        #region Variables
        private AirplaneController targetController;
        

        #endregion

        #region Builtin Methods
        private void OnEnable() {
            targetController = (AirplaneController) target;
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            GUILayout.Space(15);
            if (GUILayout.Button("Get Airplane Components", GUILayout.Height(35))) {
                
            }
            GUILayout.Space(15);
        }
        #endregion
    }
}

