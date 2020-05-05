using System.Collections.Generic;
using Carpenter.Constants;
using DefaultNamespace;
using DefaultNamespace.Managers;
using UnityEngine;

namespace Carpenter.Animation.Player {
    [CreateAssetMenu(fileName = "New Attack", menuName = AssetMenuConstants.ABILITY_PATHS + "Attack", order = 0)]
    public class Attack : BaseStateData {
        public float startAttackTime;
        public float endAtackTime;
        
        
        public List<string> colliderNames = new List<string>();
        public bool mustCollide;
        public bool mustFaceAttacker;
        public float lethalRangge;
        public int maxHits;
        public List<RuntimeAnimatorController> deathAnimators = new List<RuntimeAnimatorController>();

        public override void UpdateAbility(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            RegisterAttack(baseBehaviour,animator,stateInfo);
            DeRegisterAttack(baseBehaviour,animator,stateInfo);
        }

        public override void OnEnter(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            animator.SetBool(TransitionParameter.attack.ToString(), false);

            // create an attack info.
            GameObject obj  = Instantiate(Resources.Load("AttackInfo", typeof(GameObject))) as GameObject;
            AttackInfo info = obj.GetComponent<AttackInfo>();
            info.ResetInfo(this);

            // added attack info to attack amanager
            if (!AttackManager.Instance.currentAttacks.Contains(info)) {
                AttackManager.Instance.currentAttacks.Add(info);
            }
        }

        public override void OnExit(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            ClearAttack();
        }

        public void RegisterAttack(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            if (startAttackTime <= stateInfo.normalizedTime && endAtackTime > stateInfo.normalizedTime) {
                foreach (AttackInfo info in AttackManager.Instance.currentAttacks) {
                    if (info == null) {
                        continue;
                    }

                    if (!info.isRegistered && info.attackAbility == this) {
                        info.Register(this, (MoveController) baseBehaviour.GetMoveController(animator));
                    }
                }
            }
        }

        public void DeRegisterAttack(BaseStateMachineBehaviour baseBehaviour, Animator animator, AnimatorStateInfo stateInfo) {
            if (endAtackTime <= stateInfo.normalizedTime) {
                foreach (AttackInfo info in AttackManager.Instance.currentAttacks) {
                    if (info == null) {
                        continue;
                    }

                    if (!info.isFinished && info.attackAbility == this) {
                        info.isFinished = true;
                        Destroy(info.gameObject);
                    }
                }
            }
        }

        public void ClearAttack() {
            for (var i = 0; i < AttackManager.Instance.currentAttacks.Count; i++) {
                if (AttackManager.Instance.currentAttacks[i] == null || AttackManager.Instance.currentAttacks[i].isFinished) {
                    AttackManager.Instance.currentAttacks.RemoveAt(i);
                }
            }
        }

        public RuntimeAnimatorController GetDeathAnimator() {
            int index = Random.Range(0, deathAnimators.Count);
            return deathAnimators[index];
        }
    }
}