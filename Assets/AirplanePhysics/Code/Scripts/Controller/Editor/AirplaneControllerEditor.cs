using System.Collections.Generic;
using System.Linq;
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
            if (GUILayout.Button("Get Airplane Components", GUILayout.Height(20), GUILayout.Width(200))) {
                targetController.engines.Clear();
                targetController.wheels.Clear();
                targetController.controlSurfaces.Clear();
                
                targetController.engines = FindAllEngines();
                targetController.wheels = FindAllWheels();
                targetController.controlSurfaces = FindAllControlSurfaces();
            }
            GUILayout.Space(15);

            if (GUILayout.Button("Create Airplane Preset", GUILayout.Height(20), GUILayout.Width(200))) {
                var path = EditorUtility.SaveFilePanel("Save Airplane Preset", "Assets", "New Airplane Preset", "asset");
                SaveAirplanePreset(path);
            }
        }
        #endregion



        #region Custom Methods
        private List<AirplaneEngine> FindAllEngines() {
            var engines = new List<AirplaneEngine>();
            if (targetController) engines = targetController.transform.GetComponentsInChildren<AirplaneEngine>().ToList();
            return engines;
        } 
        
        
        private List<AirplaneWheel> FindAllWheels() {
            var wheels = new List<AirplaneWheel>();
            if (targetController) wheels = targetController.transform.GetComponentsInChildren<AirplaneWheel>().ToList();
            return wheels;
        } 

        
        private List<AirplaneControlSurface> FindAllControlSurfaces() {
            var controlSurfaces = new List<AirplaneControlSurface>();
            if (targetController) controlSurfaces = targetController.transform.GetComponentsInChildren<AirplaneControlSurface>().ToList();
            return controlSurfaces;
        }

        
        private void SaveAirplanePreset(string assetPath) {
            if (targetController && !string.IsNullOrEmpty(assetPath)) {
                var appPath = Application.dataPath;
                var finalPath = "Assets/" + assetPath.Substring(appPath.Length);
                
                var newPreset = CreateInstance<AirplanePreset>();
                newPreset.airplaneWeight = targetController.airplaneWeight;
                if (targetController.centerOfMass) newPreset.comPosition = targetController.centerOfMass.localPosition;

                if (targetController.characteristics) {
                    newPreset.maxMPH = targetController.characteristics.maxMPH;
                    newPreset.rbLerpSpeed = targetController.characteristics.rbLerpSpeed;
                    newPreset.maxLiftPower = targetController.characteristics.maxLiftPower;
                    newPreset.liftCurve = targetController.characteristics.liftCurve;
                    newPreset.dragFactor = targetController.characteristics.dragFactor;
                    newPreset.flapDragFactor = targetController.characteristics.flapDragFactor;
                    newPreset.pitchSpeed = targetController.characteristics.pitchSpeed;
                    newPreset.rollSpeed = targetController.characteristics.rollSpeed;
                    newPreset.yawSpeed = targetController.characteristics.yawSpeed;
                }
                
                AssetDatabase.CreateAsset(newPreset, finalPath);
            }
        }
        #endregion
    }
}