using UnityEngine;

namespace DefaultNamespace {
    public class ColliderTrigger : MonoBehaviour {
        private MoveController owner;

        private void Awake() {
            owner = GetComponentInParent<MoveController>();
        }

        private void OnTriggerEnter(Collider other) {
            if (owner.ragdollParts.Contains(other)) {
                return;
            }

            // get the controller of the touched object.
            MoveController controller = other.transform.root.GetComponent<MoveController>();
            if (controller != null && other.gameObject != gameObject) {
                if (!owner.collidingParts.Contains(other)) {
                    owner.collidingParts.Add(other);
                }
            }
        }

        private void OnTriggerExit(Collider other) {
            if (owner.collidingParts.Contains(other)) {
                owner.collidingParts.Remove(other);
            }
        }
    }
}