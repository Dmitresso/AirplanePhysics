using System;
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
            if (GUILayout.Button("Get Airplane Components", GUILayout.Height(35))) {
                targetController.engines.Clear();
                targetController.wheels.Clear();
                targetController.controlSurfaces.Clear();
                
                targetController.engines = FindAllEngines();
                targetController.wheels = FindAllWheels();
                targetController.controlSurfaces = FindAllControlSurfaces();
            }
            GUILayout.Space(15);
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
        #endregion
    }
}

