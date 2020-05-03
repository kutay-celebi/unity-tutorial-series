using Carpenter.Constants;
using DefaultNamespace;
using DefaultNamespace.Controller;
using UnityEngine;

namespace Carpenter.Animation.Player {
    /**
     * This class where idle behaviour is defined.
     */
    [CreateAssetMenu(fileName = "New Idle State", menuName = AssetMenuConstants.ABILITY_PATHS + "Idle", order = 0)]
    public class Idle : BaseStateData {
        public override void UpdateAbility(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            BaseMoveController controller = baseBehaviour.GetMoveController(animator);

            animator.SetBool(TransitionParameter.jump.ToString(), controller.jump);

            if (controller.moveRight && controller.moveLeft) {
                return;
            }

            animator.SetBool(TransitionParameter.move.ToString(), controller.moveRight || controller.moveLeft);
            
            animator.SetBool(TransitionParameter.attack.ToString(), controller.attack);
        }

        public override void OnEnter(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            // throw new NotImplementedException();
        }

        public override void OnExit(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            // throw new NotImplementedException();
        }
    }
}