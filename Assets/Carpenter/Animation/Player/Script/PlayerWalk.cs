using DefaultNamespace;
using UnityEngine;

namespace Carpenter.Animation.Player {
    public class PlayerWalk : BaseStateMachineBehaviour {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if (VirtualInputManager.Instance.moveRight && VirtualInputManager.Instance.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (!VirtualInputManager.Instance.moveRight && !VirtualInputManager.Instance.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (VirtualInputManager.Instance.moveRight) {
                GetMoveController(animator).transform.Translate(Vector3.forward * GetMoveController(animator).Speed * Time.deltaTime);
                GetMoveController(animator).transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (VirtualInputManager.Instance.moveLeft) {
                GetMoveController(animator).transform.Translate(Vector3.forward * GetMoveController(animator).Speed * Time.deltaTime);
                GetMoveController(animator).transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        }

        public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        }
    }
}