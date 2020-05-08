using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace {
    public class ColliderTrigger : MonoBehaviour {
        private MoveController owner;
        public List<Collider> collidingParts = new List<Collider>();

        public BodyParts bodyPart;

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
                if (!collidingParts.Contains(other)) {
                    collidingParts.Add(other);
                }
            }
        }

        private void OnTriggerExit(Collider other) {
            if (collidingParts.Contains(other)) {
                collidingParts.Remove(other);
            }
        }
    }
}