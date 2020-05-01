using UnityEngine;

namespace DefaultNamespace {
    /**
     * <summary>This class is an abstract class that allows to scripting state ability.  Abilities can be managed generically with this class.</summary>
     *
     * <seealso cref="CreateAssetMenuAttribute"/>
     */
    public abstract class BaseStateData : ScriptableObject {
        public float duration;

        public abstract void UpdateAbility(BaseStateMachineBehaviour baseStateMachineBehaviour, Animator animator, AnimatorStateInfo stateInfo);

        public abstract void OnEnter(BaseStateMachineBehaviour baseStateMachineBehaviour, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void OnExit(BaseStateMachineBehaviour baseStateMachineBehaviour, Animator animator, AnimatorStateInfo stateInfo);
    }
}