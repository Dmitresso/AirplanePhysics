using UnityEditor;

namespace WheelApps {
    public static class Airplane_Menus {
        [MenuItem("Airplane Tools/Create New Airplane")]
        public static void CreateNewAirplane() {
            AirplaneSetupTools.BuildDefaultAirplane();
        }
    }
}