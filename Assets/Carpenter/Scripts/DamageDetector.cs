using DefaultNamespace.Managers;
using UnityEngine;

namespace DefaultNamespace {
    public class DamageDetector : MonoBehaviour {
        private MoveController controller;

        private void Awake() {
            controller = GetComponent<MoveController>();
        }

        private void Update() {
            if (AttackManager.Instance.currentAttacks.Count > 0) {
                CheckAttack();
            }
        }

        private void CheckAttack() {
            foreach (AttackInfo info in AttackManager.Instance.currentAttacks) {
                if (info == null) {
                    continue;
                }

                if (!info.isRegistered) {
                    continue;
                }

                if (info.isFinished) {
                    continue;
                }

                if (controller == info.attacker) {
                    continue;
                }

                if (info.currentHits >= info.maxHits) {
                    continue;
                }


                if (info.mustCollide) {
                    if (IsCollided(info)) {
                        TakeDamage(info);
                    }
                }
            }
        }

        private bool IsCollided(AttackInfo info) {
            foreach (Collider collider in controller.collidingParts) {
                foreach (string infoColliderName in info.colliderNames) {
                    if (collider.gameObject.name == infoColliderName) {
                        return true;
                    }
                }
            }

            return false;
        }

        private void TakeDamage(AttackInfo info) {
            // change animator at runtime.
            controller.skinnedMashAnimator.runtimeAnimatorController = info.attackAbility.GetDeathAnimator();
            info.currentHits++;
        }
    }
}