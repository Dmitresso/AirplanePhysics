using UnityEngine;

namespace WheelApps {
    public class AirplaneFuel : MonoBehaviour {
        #region Variables
        [Header("Fuel Properties")]
        [Tooltip("The total number of gallons in the fuel tank.")]
        public float fuelCapacity = 26f;
        [Tooltip("the average fuel burn per hour.")]
        public float fuelBurnRate = 6.1f;
        #endregion



        #region Properties
        private float currentFuel;
        public float CurrentFuel => currentFuel;
        #endregion



        #region Builtin Methods
        #endregion
        
        

        #region Custom Methods
        public void Init() {
            currentFuel = fuelCapacity;
        }
        
        public void UpdateFuel(float precentage) {
            
        }
        #endregion
    }
}