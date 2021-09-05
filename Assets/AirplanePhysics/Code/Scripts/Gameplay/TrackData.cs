using UnityEngine;


namespace WheelApps {
    [CreateAssetMenu(fileName = "NewTrackData", menuName = "WheelApps/Track Data/New Track Data", order = 1)]
    public class TrackData : ScriptableObject {
        #region Variables
        public float lastTrackTime;
        public float bestTrackTime;
        public float lastTrackScore;
        public float bestTrackScore;
        #endregion



        #region Custom Methods
        public void SetTimes(float time) {
            lastTrackTime = time;
            if (bestTrackTime == 0) {
                bestTrackTime = lastTrackTime;
            }
            else if (lastTrackTime < bestTrackTime) {
                bestTrackTime = lastTrackTime;
            }
            
        }


        public void SetScore(float score) {
            lastTrackScore = score;
            if (lastTrackScore > bestTrackScore) bestTrackScore = lastTrackScore;
            
        }
        #endregion
    }
}