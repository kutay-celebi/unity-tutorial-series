using DefaultNamespace;
using UnityEngine;

namespace Carpenter.Animation.Player {
    /**
     * This class where forward walking behaviour is defined.
     */
    [CreateAssetMenu(fileName = "New State", menuName = "Carpenter/AbilityData/MoveForward")]
    public class MoveForward : BaseStateData {
        public float speed;

        public override void UpdateAbility(BaseStateMachineBehaviour baseStateMachineBehaviour, Animator animator) {
            MoveController controller = baseStateMachineBehaviour.GetMoveController(animator);
            if (VirtualInputManager.Instance.moveRight && VirtualInputManager.Instance.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (!VirtualInputManager.Instance.moveRight && !VirtualInputManager.Instance.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (VirtualInputManager.Instance.moveRight) {
                controller.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                controller.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (VirtualInputManager.Instance.moveLeft) {
                controller.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                controller.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }
}