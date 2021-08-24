using UnityEditor;
using UnityEngine;

namespace WheelApps {
    public static class Airplane_Menus {
        [MenuItem("Airplane Tools/Create New Airplane")]
        public static void CreateNewAirplane() {
            GameObject currentSelected = Selection.activeGameObject;
            if (currentSelected) {
                Airplane_Controller currentController = currentSelected.AddComponent<Airplane_Controller>();
                GameObject currentCOM = new GameObject("COM");
                currentCOM.transform.SetParent(currentSelected.transform);

                currentController.centerOfMass = currentCOM.transform;
            }
        }
    }
}