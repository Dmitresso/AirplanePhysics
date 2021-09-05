using UnityEditor;
using UnityEngine;


namespace WheelApps {
    public static class AirplaneSetupTools {
        public static void BuildDefaultAirplane(string airplaneName) {
            var rootGO = new GameObject(airplaneName, typeof(AirplaneController), typeof(BaseAirplaneInput));
            var comGO = new GameObject("COM");
            comGO.transform.SetParent(rootGO.transform, false);
 
            var input = rootGO.GetComponent<BaseAirplaneInput>();
            var controller = rootGO.GetComponent<AirplaneController>();
            var characteristics = rootGO.GetComponent<AirplaneCharacteristics>();

            if (controller) {
                controller.input = input;
                controller.characteristics = characteristics;
                controller.centerOfMass = comGO.transform;

                var graphicsGRP = new GameObject("Graphics_GRP");
                var collisionGRP = new GameObject("Collision_GRP");
                var controlSurfacesGRP = new GameObject("ControlSurfaces_GRP");
                
                graphicsGRP.transform.SetParent(rootGO.transform, false);
                collisionGRP.transform.SetParent(rootGO.transform, false);
                controlSurfacesGRP.transform.SetParent(rootGO.transform, false);

                var engineGO = new GameObject("Engine", typeof(AirplaneEngine));
                var engine = engineGO.GetComponent<AirplaneEngine>();
                controller.engines.Add(engine);
                engineGO.transform.SetParent(rootGO.transform, false);

                var assetPath = "Assets/AirplanePhysics/Art/Objects/Airplanes/Indie-Pixel_Airplane/IndiePixel_Airplane.fbx";
                var defaultAirplane = (GameObject) AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject));

                if (defaultAirplane) GameObject.Instantiate(defaultAirplane, graphicsGRP.transform);
            }

            Selection.activeGameObject = rootGO;
        }
    }
}