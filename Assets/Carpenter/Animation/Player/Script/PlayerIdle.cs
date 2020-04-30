using DefaultNamespace;
using UnityEngine;

namespace Carpenter.Animation.Player {
    /**
     * For state in an animator. This class where the idle behavior of the model is managed.
     */
    public class PlayerIdle : BaseStateMachineBehaviour {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if (VirtualInputManager.Instance.moveRight) {
                animator.SetBool(TransitionParameter.move.ToString(), true);
            }

            if (VirtualInputManager.Instance.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), true);
            }
        }

        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        }

        public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        }
    }
}