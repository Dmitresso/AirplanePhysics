using UnityEngine;
using UnityEngine.Events;

namespace WheelApps {
    public class AirplaneFuel : MonoBehaviour {
        #region Variables
        [Header("Fuel Properties")]
        [Tooltip("The total number of gallons in the fuel tank.")]
        public float fuelCapacity = 26f;
        [Tooltip("The average fuel burn per hour.")]
        public float fuelBurnRate = 6.1f;

        [Header("Events")]
        public UnityEvent onFuelFull = new UnityEvent();
        #endregion



        #region Properties
        private float currentFuel;
        public float CurrentFuel => currentFuel;

        private float normalizedFuel;
        public float NormalizedFuel => normalizedFuel;
        #endregion



        #region Builtin Methods
        #endregion
        
        

        #region Custom Methods
        public void Init() {
            currentFuel = fuelCapacity;
        }

        public void AddFuel(float fuelAmount) {
            currentFuel += fuelAmount;
            currentFuel = Mathf.Clamp(currentFuel, 0f, fuelCapacity);
            if (currentFuel >= fuelCapacity) onFuelFull?.Invoke();
        }

        public void ResetFill() {
            currentFuel = fuelCapacity;
        }
        
        public void UpdateFuel(float percentage) {
            var currentBurn = fuelBurnRate * percentage / 3600f * Time.deltaTime;
            currentFuel -= currentBurn;
            currentFuel = Mathf.Clamp(currentFuel, 0f, fuelCapacity);
            normalizedFuel = currentFuel / fuelCapacity;
        }
        #endregion
    }
}