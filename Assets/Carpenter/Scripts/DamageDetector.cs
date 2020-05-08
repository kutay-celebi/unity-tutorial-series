using DefaultNamespace.Managers;
using UnityEngine;

namespace DefaultNamespace {
    public class DamageDetector : MonoBehaviour {
        private MoveController controller;
        public BodyParts damagedPart;


        // private List<ColliderTrigger> colliderTrigers = new List<ColliderTrigger>();

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
            foreach (ColliderTrigger detector in controller.GetAllTriggers()) {
                foreach (Collider collider in detector.collidingParts) {
                    foreach (string infoColliderName in info.colliderNames) {
                        if (collider.gameObject.name == infoColliderName) {
                            damagedPart = detector.bodyPart;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void TakeDamage(AttackInfo info) {
            Debug.Log(info.attacker.gameObject.name + " attacked to " + controller.gameObject.name + " from " + damagedPart);

            // change animator at runtime.
            controller.skinnedMashAnimator.runtimeAnimatorController = info.attackAbility.GetDeathAnimator();
            info.currentHits++;

            BoxCollider boxCollider = controller.GetComponent<BoxCollider>();
            boxCollider.enabled             = false;
            controller.Rigidbody.useGravity = false;
        }
    }
}