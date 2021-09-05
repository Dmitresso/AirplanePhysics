using UnityEditor;
using UnityEngine;


namespace WheelApps {
    public class AirplaneSetupWindow : EditorWindow {
        #region Variables
        private string targetName;
        

        #endregion



        #region Builtin Methods
        private void OnGUI() {
            targetName = EditorGUILayout.TextField("Airplane Name:", targetName);
            if (GUILayout.Button("Build New Airplane") && !string.IsNullOrEmpty(targetName)) {
                AirplaneSetupTools.BuildDefaultAirplane(targetName);
                GetWindow<AirplaneSetupWindow>().Close();
            }
        }

        #endregion

        
        
        #region Custom Methods
        public static void LaunchSetupWindow() {
            GetWindow(typeof(AirplaneSetupWindow), true, "Airplane Setup").Show();
        }
        #endregion
    }
}