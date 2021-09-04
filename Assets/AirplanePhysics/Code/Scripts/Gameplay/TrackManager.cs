using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace WheelApps {
    public class TrackManager : MonoBehaviour {
        #region Variables
        [Header("Manager Properties")]
        public List<Track> tracks = new List<Track>();
        public AirplaneController airplane;

        [Header("Manager UI")]
        public Text gateText;
        public Text timeText;
        public Text scoreText;
        
        [Header("Manager Events")]
        public UnityEvent OnCompletedRace = new UnityEvent();


        private Track currentTrack;
        #endregion



        #region Builtin Methods
        private void Start() {
            FindTracks();
            InitTracks();
            
            StartTrack(0);
        }


        private void Update() {
            if (currentTrack) UpdateUI();
        }
        #endregion



        #region Custom Methods
        private void FindTracks() {
            tracks.Clear();
            tracks = GetComponentsInChildren<Track>(true).ToList();
        }

        
        private void InitTracks() {
            if (tracks.Count <= 0) return;
            foreach (var track in tracks) {
                track.OnCompletedTrack.AddListener(CompletedTrack);
            }
        }

        
        public void StartTrack(int trackID) {
            if (trackID < 0 || trackID > tracks.Count) return;
            for (var i = 0; i < tracks.Count; i++) {
                if (i != trackID) tracks[i].gameObject.SetActive(false);
                tracks[trackID].gameObject.SetActive(true);
                tracks[trackID].StartTrack();
                currentTrack = tracks[trackID];
            }
        }


        private void CompletedTrack() {
            if (airplane) StartCoroutine(nameof(WaitForLanding));
        }

        private IEnumerator WaitForLanding() {
            if (airplane.State != AirplaneState.LANDED) yield return null;
            OnCompletedRace?.Invoke();
        }


        private void UpdateUI() {
            if (gateText) {
                
            }

            if (scoreText) {
                
            }

            if (timeText) {
                
            }
        }
        #endregion
    }
}
