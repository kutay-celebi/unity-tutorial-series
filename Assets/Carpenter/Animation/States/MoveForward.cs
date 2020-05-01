using Carpenter.Constants;
using DefaultNamespace;
using DefaultNamespace.Controller;
using UnityEngine;

namespace Carpenter.Animation.Player {
    [CreateAssetMenu(fileName = "New File", menuName = AssetMenuConstants.ABILITY_PATHS + "MoveForward", order = 0)]
    public class MoveForward : BaseStateData {
        public float speed;

        public override void UpdateAbility(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            BaseMoveController controller = baseBehaviour.GetMoveController(animator);
            if (controller.moveRight && controller.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (!controller.moveRight && !controller.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (controller.moveRight) {
                controller.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                controller.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (controller.moveLeft) {
                controller.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                controller.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        public override void OnEnter(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            // throw new System.NotImplementedException();
        }

        public override void OnExit(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            // throw new System.NotImplementedException();
        }
    }
}