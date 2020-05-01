using System;
using System.Collections.Generic;
using DefaultNamespace.Controller;
using UnityEngine;

namespace DefaultNamespace {
    public enum TransitionParameter {
        move,
        jump,
        forceTransition
    }

    //todo create base controller.
    public class MoveController : BaseMoveController {
        public float Speed;
        public Material material;
        public GameObject colliderEdge;

        private List<GameObject> bottomSpheres;

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
            float       bottom = box.bounds.center.y - box.bounds.extents.y;
            float       top    = box.bounds.center.y + box.bounds.extents.y;
            float       front  = box.bounds.center.z + box.bounds.extents.z;
            float       back   = box.bounds.center.z - box.bounds.extents.z;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(0f, bottom, front));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(0f, bottom, back));

            bottomFront.transform.parent = transform;

            bottomBack.transform.parent = transform;
            bottomSpheres.Add(bottomBack);
            bottomSpheres.Add(bottomFront);
        }

        public GameObject CreateEdgeSphere(Vector3 position) {
            GameObject obj = Instantiate(colliderEdge, position, Quaternion.identity);
            return obj;
        }
    }
}