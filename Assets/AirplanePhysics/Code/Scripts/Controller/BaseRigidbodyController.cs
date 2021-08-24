using UnityEngine;

namespace WheelApps {
    [RequireComponent(typeof(Rigidbody),
                     typeof(AudioSource))]
    public class BaseRigidbodyController : MonoBehaviour {
        #region Variables
        protected Rigidbody rb;
        protected AudioSource audioSource;
        #endregion

        
        
        #region Builtin Methods
        public virtual void Start() {
            rb = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();
            if (audioSource) audioSource.playOnAwake = false;
        }


        private void FixedUpdate() {
            if (rb) HandlePhysics();
        }

        #endregion
        
        
        
        #region Custom Methods
        protected virtual void HandlePhysics() {
            
        }
        #endregion
    }
}