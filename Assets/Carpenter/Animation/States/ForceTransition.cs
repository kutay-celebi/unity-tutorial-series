using System;
using Carpenter.Constants;
using DefaultNamespace;
using UnityEngine;

namespace Carpenter.Animation.Player {
    /**
     * This class where forward walking behaviour is defined.
     */
    [CreateAssetMenu(fileName = "New State", menuName = AssetMenuConstants.ABILITY_PATHS + "ForceTransition")]
    public class ForceTransition : BaseStateData {
        [Range(0.01f, 1f)]
        public float transitionTiming;

        public override void UpdateAbility(BaseStateMachineBehaviour baseStateMachineBehaviour, Animator animator,
                                           AnimatorStateInfo stateInfo) {
            if (stateInfo.normalizedTime >= transitionTiming) {
                animator.SetBool(TransitionParameter.forceTransition.ToString(), true);
            }
        }

        public override void OnEnter(BaseStateMachineBehaviour baseStateMachineBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            // throw new NotImplementedException();
        }

        public override void OnExit(BaseStateMachineBehaviour baseStateMachineBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            animator.SetBool(TransitionParameter.forceTransition.ToString(), false);
        }
    }
}