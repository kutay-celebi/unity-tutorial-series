using DefaultNamespace;
using UnityEngine;

namespace Carpenter.Animation.Player {
    /**
     * This class where idle behaviour is defined.
     */
    [CreateAssetMenu(fileName = "New Idle State", menuName = "Carpenter/AbilityData/Idle", order = 0)]
    public class Idle : BaseStateData {
        public override void UpdateAbility(BaseStateMachineBehaviour baseStateMachineBehaviour, Animator animator) {
            MoveController controller = baseStateMachineBehaviour.GetMoveController(animator);

            if (VirtualInputManager.Instance.moveRight) {
                animator.SetBool(TransitionParameter.move.ToString(), true);
            }

            if (VirtualInputManager.Instance.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), true);
            }
        }
    }
}