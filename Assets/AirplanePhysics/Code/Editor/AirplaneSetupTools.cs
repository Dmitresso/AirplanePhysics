using UnityEditor;
using UnityEngine;

namespace WheelApps {
    public static class AirplaneSetupTools {
        public static void BuildDefaultAirplane() {
            var rootGO = new GameObject("New Airplane", typeof(AirplaneController), typeof(BaseAirplaneInput));
            var comGO = new GameObject("COM");
            comGO.transform.SetParent(rootGO.transform, false);
            
            // if (currentSelected) {
            //     AirplaneController currentController = currentSelected.AddComponent<AirplaneController>();
            //     GameObject currentCOM = new GameObject("COM");
            //     currentCOM.transform.SetParent(currentSelected.transform);
            //
            //     currentController.centerOfMass = currentCOM.transform;
            // }
        }
    }
}