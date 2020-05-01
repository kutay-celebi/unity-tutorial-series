using UnityEngine;

namespace DefaultNamespace.Controller {
    public class BaseMoveController : MonoBehaviour {
        public Animator animator;
        private Rigidbody rigidbody;
        public Rigidbody RIGID_BODY;

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