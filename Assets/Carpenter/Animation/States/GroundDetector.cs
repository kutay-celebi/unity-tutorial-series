using Carpenter.Constants;
using DefaultNamespace;
using UnityEngine;

namespace Carpenter.Animation.Player {
    [CreateAssetMenu(fileName = "New File", menuName = AssetMenuConstants.ABILITY_PATHS + "GroundDetector", order = 0)]
    public class GroundDetector : BaseStateData {
        [Range(0.01f, 1f)]
        public float checkTime;
        public float distance;

        public override void UpdateAbility(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            MoveController controller = (MoveController) baseBehaviour.GetMoveController(animator);

            if (stateInfo.normalizedTime >= checkTime) {
                if (IsGrounded(controller)) {
                    animator.SetBool(TransitionParameter.grounded.ToString(), true);
                } else {
                    animator.SetBool(TransitionParameter.grounded.ToString(), false);
                }
            }
        }

        public override void OnEnter(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            // do nothing
        }

        public override void OnExit(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            // do nothing
        }

        bool IsGrounded(MoveController controller) {
            if (controller.RIGID_BODY.velocity.y > -0.01f && controller.RIGID_BODY.velocity.y <= 0f) {
                return true;
            }

            foreach (GameObject sphere in controller.bottomSpheres) {
                // Debug.DrawRay(sphere.transform.position, -Vector3.up * distance, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(sphere.transform.position, -Vector3.up, out hit, distance)) {
                    return true;
                }
            }

            return false;
        }
    }
}