using System;
using System.Collections.Generic;
using DefaultNamespace.Controller;
using UnityEngine;

namespace DefaultNamespace {
    public enum TransitionParameter {
        move,
        jump,
        forceTransition,
        grounded
    }

    //todo create base controller.
    public class MoveController : BaseMoveController {
        public float Speed;
        public Material material;
        public GameObject colliderEdge;

        public readonly List<GameObject> bottomSpheres = new List<GameObject>();

        // Update is called once per frame
        void Update() {
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

        private void Awake() {
            BoxCollider box    = GetComponent<BoxCollider>();
            var bounds = box.bounds;
            float       bottom = bounds.center.y - bounds.extents.y;
            float       top    = bounds.center.y + bounds.extents.y;
            float       front  = bounds.center.z + bounds.extents.z;
            float       back   = bounds.center.z - bounds.extents.z;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(0f, bottom, front));
            GameObject bottomBack  = CreateEdgeSphere(new Vector3(0f, bottom, back));

            Transform transform1 = transform;
            bottomFront.transform.parent = transform1;
            bottomBack.transform.parent = transform1;
            bottomSpheres.Add(bottomBack);
            bottomSpheres.Add(bottomFront);

            float vectorSection = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;

            for (int i = 0; i < 4; i++) {
                Vector3    pos       = bottomBack.transform.position + (Vector3.forward * vectorSection * (i + 1));
                GameObject newSphere = CreateEdgeSphere(pos);
                newSphere.transform.parent = this.transform;
                bottomSpheres.Add(newSphere);
            }
        }

        public GameObject CreateEdgeSphere(Vector3 position) {
            GameObject obj = Instantiate(colliderEdge, position, Quaternion.identity);
            return obj;
        }
    }
}