using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WheelApps {
    public class TrackManager : MonoBehaviour {
        #region Variables
        [Header("Manager Properties")]
        public List<Track> tracks = new List<Track>();
        public AirplaneController airplane;

        #endregion



        #region Builtin Methods
        private void Start() {
            FindTracks();
            InitTracks();
            
            StartTrack(0);
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


        private void CompletedTrack() {
            
        }
        
        
        public void StartTrack(int trackID) {
            if (trackID < 0 || trackID > tracks.Count) return;
            for (var i = 0; i < tracks.Count; i++) {
                if (i != trackID) tracks[i].gameObject.SetActive(false);
                tracks[trackID].gameObject.SetActive(true);
                tracks[trackID].StartTrack();
            }
        }
        #endregion
    }
}
