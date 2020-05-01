using System;
using UnityEngine;

namespace DefaultNamespace {
    public enum TransitionParameter {
        move,
        jump,
        forceTransition
    }

    //todo create base controller.
    public class MoveController : MonoBehaviour {
        public float Speed;
        public Animator animator;
        public Material material;


        public bool moveRight;
        public bool moveLeft;
        public bool jump;

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
    }
}