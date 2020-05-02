using UnityEngine;

namespace DefaultNamespace.Controller {
    public class BaseMoveController : MonoBehaviour {
        
        [Header("Animator")]
        public Animator animator;
        // public Rigidbody RIGID_BODY;
        private Rigidbody rigidbody;

        [Header("Movement Variable")]
        public bool moveRight;
        public bool moveLeft;
        public bool jump;

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