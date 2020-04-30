using UnityEngine;

namespace DefaultNamespace {
    public class BaseStateMachineBehaviour : StateMachineBehaviour {
        // todo migrate singleton etc.
        private CharacterMoveController moveController;


        public CharacterMoveController GetMoveController(Animator animator) {
            if (moveController == null) {
                moveController = animator.GetComponentInParent<CharacterMoveController>();
            }

            return moveController;
        }
    }
}