using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace {
    public class BaseStateMachineBehaviour : StateMachineBehaviour {
        public List<BaseStateData> listAbilityData = new List<BaseStateData>();

        // todo migrate singleton etc.
        private CharacterMoveController moveController;

        public void UpdateAll(BaseStateMachineBehaviour stateBase, Animator animator) {
            foreach (BaseStateData data in listAbilityData) {
                data.UpdateAbility(stateBase, animator);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateAll(this, animator);
        }

        public CharacterMoveController GetMoveController(Animator animator) {
            if (moveController == null) {
                moveController = animator.GetComponentInParent<CharacterMoveController>();
            }

            return moveController;
        }
    }
}