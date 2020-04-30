using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace {
    /**
     * Base state machine behaviour for animators.
     */
    public class BaseStateMachineBehaviour : StateMachineBehaviour {
        /**
         * <summary>List of abilities which are extended from <see cref="BaseStateData"/>. </summary>
         */
        public List<BaseStateData> listAbilityData = new List<BaseStateData>();

        // todo migrate singleton etc.
        /**
         * <summary>
         * Moving controller for model. <see cref="MoveController"/>
         * </summary>
         */
        private MoveController moveController;

        /**
         * <summary>Updates all states in list of state </summary>
         */
        public void UpdateAll(BaseStateMachineBehaviour stateBase, Animator animator) {
            foreach (BaseStateData data in listAbilityData) {
                data.UpdateAbility(stateBase, animator);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateAll(this, animator);
        }

        /**
         * Return <see cref="moveController"/> of model.
         */
        public MoveController GetMoveController(Animator animator) {
            if (moveController == null) {
                moveController = animator.GetComponentInParent<MoveController>();
            }

            return moveController;
        }
    }
}