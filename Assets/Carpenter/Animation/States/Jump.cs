using Carpenter.Constants;
using DefaultNamespace;
using UnityEngine;

namespace Carpenter.Animation.Player {
    [CreateAssetMenu(fileName = "New File", menuName = AssetMenuConstants.ABILITY_PATHS + "Jump", order = 0)]
    public class Jump : BaseStateData {
        public float jumpForce;
        public AnimationCurve gravity;
        public AnimationCurve pull;

        public override void UpdateAbility(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            MoveController controller = (MoveController) baseBehaviour.GetMoveController(animator);
            controller.gravityMultiplier = gravity.Evaluate(stateInfo.normalizedTime);
            controller.pullMultiplier    = pull.Evaluate(stateInfo.normalizedTime);
        }

        public override void OnEnter(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            baseBehaviour.GetMoveController(animator).Rigidbody.AddForce(Vector3.up * jumpForce);
            animator.SetBool(TransitionParameter.grounded.ToString(), false);
        }

        public override void OnExit(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            // do nothing.
        }
    }
}