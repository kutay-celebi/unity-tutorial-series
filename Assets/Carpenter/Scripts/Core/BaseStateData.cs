using UnityEngine;

namespace DefaultNamespace {
    public abstract class BaseStateData : ScriptableObject {
        public float duration;

        public abstract void UpdateAbility(BaseStateMachineBehaviour baseStateMachineBehaviour, Animator animator);
    }
}