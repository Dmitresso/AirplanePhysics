using UnityEditor;

namespace WheelApps {
    public static class AirplaneMenus {
        [MenuItem("Airplane Tools/Create New Airplane")]
        public static void CreateNewAirplane() {
            AirplaneSetupTools.BuildDefaultAirplane();
        }
    }
}