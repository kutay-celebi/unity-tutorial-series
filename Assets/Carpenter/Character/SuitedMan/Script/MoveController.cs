using System;
using System.Collections;
using System.Collections.Generic;
using Carpenter.Constants;
using DefaultNamespace.Controller;
using UnityEngine;

namespace DefaultNamespace {
    public enum TransitionParameter {
        move,
        jump,
        forceTransition,
        grounded,
        attack
    }

    //todo create base controller.
    public class MoveController : BaseMoveController {
        [Header("Gravity")]
        public float gravityMultiplier;
        public float pullMultiplier;

        public float Speed;
        public Material material;
        public GameObject colliderEdge;

        public readonly List<GameObject> bottomSpheres = new List<GameObject>();
        public readonly List<GameObject> frontSpheres = new List<GameObject>();
        public List<Collider> ragdollParts = new List<Collider>();
        public List<Collider> collidingParts = new List<Collider>();

        // Update is called once per frame
        void Update() {
        }

        private void FixedUpdate() {
            if (Rigidbody.velocity.y < 0f) {
                Rigidbody.velocity += -Vector3.up * gravityMultiplier;
            }

            if (Rigidbody.velocity.y > 0f && jump) {
                Rigidbody.velocity += (-Vector3.up * pullMultiplier);
            }
        }

        private void Awake() {
            CreateSphereOnSection(Side.BOTTOM, 6, bottomSpheres);
            CreateSphereOnSection(Side.FRONT, 10, frontSpheres);
            SetRagdollParts();

            bool switchBack = !IsFacingForward();

            FaceForward(true);

            if (switchBack) {
                FaceForward(false);
            }
        }

        private void SetRagdollParts() {
            Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();

            foreach (Collider collider in colliders) {
                if (collider.gameObject != gameObject) {
                    collider.isTrigger = true;
                    ragdollParts.Add(collider);
                }
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (ragdollParts.Contains(other)) {
                return;
            }

            // get the controller of the touched object.
            MoveController controller = transform.GetComponent<MoveController>();
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

        public void MoveForward(float speed, float speedGraph) {
            transform.Translate(Vector3.forward * speed * speedGraph *Time.deltaTime);
        }

        public void FaceForward(bool forward) {
            if (forward) {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            } else {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        public bool IsFacingForward() {
            return transform.forward.z > 0f;
        }

        public void TurnOnRagdoll() {
            Rigidbody.useGravity                           = false;
            Rigidbody.velocity                             = Vector3.zero;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            skinnedMashAnimator.enabled                    = false;
            skinnedMashAnimator.avatar                     = null;

            foreach (Collider part in ragdollParts) {
                part.isTrigger                  = false;
                part.attachedRigidbody.velocity = Vector3.zero;
            }
        }

        public void ChangeMaterial() {
            if (material == null) {
                throw new Exception("Material is null");
            }

            Renderer[] arrMaterials = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in arrMaterials) {
                if (r.gameObject != this.gameObject) {
                    r.material = material;
                }
            }
        }

        /**
         * Create spheres to check if this object are touching an other object.
         */
        private void CreateSphereOnSection(Side side, int point, List<GameObject> sphereList) {
            // get collider center point.
            BoxCollider box    = GetComponent<BoxCollider>();
            var         bounds = box.bounds;
            float       top    = bounds.center.y + bounds.extents.y;
            float       bottom = bounds.center.y - bounds.extents.y;
            float       front  = bounds.center.z + bounds.extents.z;
            float       back   = bounds.center.z - bounds.extents.z;

            Vector3 firstPoint = new Vector3();
            Vector3 lastPoint  = new Vector3();
            Vector3 direction  = new Vector3();

            switch (side) {
                case Side.BOTTOM: {
                    firstPoint = new Vector3(0f, bottom, front);
                    lastPoint  = new Vector3(0f, bottom, back);
                    direction  = Vector3.forward;
                    break;
                }
                case Side.FRONT: {
                    firstPoint = new Vector3(0f, bottom, front);
                    lastPoint  = new Vector3(0f, top, front);
                    direction  = -Vector3.up;
                    break;
                }
            }

            float vectorSection = (firstPoint - lastPoint).magnitude / (point - 1);
            for (int i = 0; i < point; i++) {
                Vector3    pos       = lastPoint + (direction * vectorSection * (i));
                GameObject newSphere = CreateEdgeSphere(pos);
                newSphere.transform.parent = transform;
                sphereList.Add(newSphere);
            }
        }

        public GameObject CreateEdgeSphere(Vector3 position) {
            GameObject obj = Instantiate(colliderEdge, position, Quaternion.identity);
            return obj;
        }
    }
}