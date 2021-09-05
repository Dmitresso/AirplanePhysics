using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


namespace WheelApps {
    public class Track : MonoBehaviour {
        #region Variables
        [Header("Track Properties")]
        public TrackData trackData;
        public List<Gate> gates = new List<Gate>();

        [Header("Track Events")]
        public UnityEvent OnCompletedTrack = new UnityEvent();

        private float startTime;
        private int currentTime;
        #endregion



        #region Properties
        private int currentGateId;
        public int CurrentGateId => currentGateId;

        private int totalGates;
        public int TotalGates => totalGates;

        private int currentMinutes;
        public int CurrentMinutes => currentMinutes;

        private int currentSeconds;
        public int CurrentSeconds => currentSeconds;

        private int currentScore;
        public int CurrentScore => currentScore;

        private bool isComplete;
        public bool IsComplete {
            get => isComplete;
            set => isComplete = value;
        }
        #endregion
        
        

        #region Builtin Methods
        private void Start() {
            FindGates();
            InitializeGates();

            currentGateId = 0;
            StartTrack();
        }


        private void Update() {
            if (!isComplete) UpdateStats();
        }


        private void OnDrawGizmos() {
            if (gates.Count <= 0) return;
            for (var i = 0; i < gates.Count; i++) {
                if (i + 1 == gates.Count) break;
                Gizmos.color = new Color(0.5f, 0.2f, 0.6f, 0.5f);
                Gizmos.DrawLine(gates[i].transform.position, gates[i + 1].transform.position);
            }
        }
        #endregion



        #region Custom Methods
        public void StartTrack() {
            if (gates.Count <= 0) return;
            startTime = Time.time;
            currentScore = 0;
            isComplete = false;
            gates[currentGateId].ActivateGate();
        }
        
        
        private void SelectNextGate(float distancePercentage) {
            var score = Mathf.RoundToInt(distancePercentage * 100f);
            score = Mathf.Clamp(currentScore, 0, 100);
            currentScore += score;
            
            currentGateId++;
            if (currentGateId == gates.Count) OnCompletedTrack?.Invoke();
            gates[currentGateId].ActivateGate();
        }
        
        
        private void FindGates() {
            gates.Clear(); 
            gates = GetComponentsInChildren<Gate>().ToList();
            totalGates = gates.Count;
        }

        
        private void InitializeGates() {
            if (gates.Count <= 0) return; 
            foreach (var gate in gates) {
                gate.DeactivateGate();
                gate.OnClearedGate.AddListener(SelectNextGate);
            }
        }

        
        private void UpdateStats() {
            currentTime = (int) (Time.time - startTime);
            currentMinutes = (int) (currentTime / 60f);
            currentSeconds = currentTime - currentMinutes * 60;
        }


        public void SaveTrackData() {
            if (!trackData) return;
            trackData.SetTimes(currentTime);
            trackData.SetScore(currentScore);
        }
        #endregion
    }
}