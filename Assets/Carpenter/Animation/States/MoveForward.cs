using System.Linq;
using Carpenter.Constants;
using DefaultNamespace;
using DefaultNamespace.Controller;
using UnityEngine;

namespace Carpenter.Animation.Player {
    [CreateAssetMenu(fileName = "New File", menuName = AssetMenuConstants.ABILITY_PATHS + "MoveForward", order = 0)]
    public class MoveForward : BaseStateData {
        public AnimationCurve speedGraph;
        public float speed;
        public float blockDistance;

        /**
         * <summary>if movement wont work with an input. constant will be true</summary>
         */
        public bool constant;

        public override void UpdateAbility(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            BaseMoveController controller = baseBehaviour.GetMoveController(animator);
            if (controller.jump) {
                animator.SetBool(TransitionParameter.jump.ToString(), true);
            }

            if (constant) {
                ConstantMove(controller, animator, stateInfo);
            } else {
                ControlledMove(controller, animator, stateInfo);
            }
        }

        public override void OnEnter(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            // do nothing
        }

        public override void OnExit(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            // do nothing
        }

        private void ConstantMove(BaseMoveController controller, Animator animator, AnimatorStateInfo stateInfo) {
            if (CheckFront((MoveController) controller)) {
                controller.transform.Translate(Vector3.forward * speed * speedGraph.Evaluate(stateInfo.normalizedTime) *
                                               Time.deltaTime);
            }
        }

        private void ControlledMove(BaseMoveController controller, Animator animator, AnimatorStateInfo stateInfo) {
            if (controller.moveRight && controller.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (!controller.moveRight && !controller.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (controller.moveRight) {
                controller.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if (CheckFront((MoveController) controller)) {
                    controller.transform.Translate(Vector3.forward * speed * speedGraph.Evaluate(stateInfo.normalizedTime) *
                                                   Time.deltaTime);
                }
            }

            if (controller.moveLeft) {
                controller.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                if (CheckFront((MoveController) controller)) {
                    controller.transform.Translate(Vector3.forward * speed * speedGraph.Evaluate(stateInfo.normalizedTime) *
                                                   Time.deltaTime);
                }
            }
        }


        bool CheckFront(MoveController controller) {
            foreach (GameObject sphere in controller.frontSpheres) {
                Debug.DrawRay(sphere.transform.position, controller.transform.forward * blockDistance, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(sphere.transform.position, controller.transform.forward, out hit, blockDistance)) {
                    if (!controller.ragdollParts.Contains(hit.collider)) {
                        if (!IsBodyPart(hit.collider)) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        bool IsBodyPart(Collider collider) {
            MoveController controller = collider.transform.root.GetComponent<MoveController>();
            if (controller == null) {
                return false;
            }

            // if self collider
            if (controller.gameObject == collider.gameObject) {
                return false;
            }

            if (controller.ragdollParts.Contains(collider)) {
                return true;
            }

            return false;
        }
    }
}