using UnityEngine;

namespace DefaultNamespace.Controller {
    public class BaseMoveController : MonoBehaviour {
        
        [Header("Animator")]
        public Animator skinnedMashAnimator;
        // public Rigidbody RIGID_BODY;
        private Rigidbody rigidbody;

        [Header("Movement Variable")]
        public bool moveRight;
        public bool moveLeft;
        public bool jump;
        public bool attack;

        public Rigidbody Rigidbody {
            get {
                if (rigidbody == null) {
                    rigidbody = GetComponent<Rigidbody>();
                }

                return rigidbody;
            }
        }
    }
}