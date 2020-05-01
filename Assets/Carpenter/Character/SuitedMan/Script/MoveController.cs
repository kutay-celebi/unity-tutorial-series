using System;
using System.Collections.Generic;
using Carpenter.Constants;
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
        public readonly List<GameObject> frontSpheres = new List<GameObject>();

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
            CreateSphereOnSection(Side.BOTTOM, 6, bottomSpheres);
            CreateSphereOnSection(Side.FRONT, 10, frontSpheres);
        }


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