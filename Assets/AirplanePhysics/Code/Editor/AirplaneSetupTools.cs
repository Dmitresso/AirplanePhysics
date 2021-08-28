using UnityEngine;

namespace WheelApps {
    public static class AirplaneSetupTools {
        public static void BuildDefaultAirplane() {
            var rootGO = new GameObject("New Airplane", typeof(AirplaneController), typeof(BaseAirplaneInput));
            var comGO = new GameObject("COM");
            comGO.transform.SetParent(rootGO.transform, false);
 
            var input = rootGO.GetComponent<BaseAirplaneInput>();
            var controller = rootGO.GetComponent<AirplaneController>();
            var characteristics = rootGO.GetComponent<AirplaneCharacteristics>();

            if (controller) {
                controller.input = input;
                controller.characteristics = characteristics;
                controller.centerOfMass = comGO.transform;
            }
        }
    }
}