using System;
using UnityEngine;

namespace DefaultNamespace {
    public enum TransitionParameter {
        move
    }


    public class CharacterMoveController : MonoBehaviour {
        public float Speed;
        public Animator animator;
        public Material material;

        // Update is called once per frame
        void Update() {
            if (VirtualInputManager.Instance.moveRight && VirtualInputManager.Instance.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (!VirtualInputManager.Instance.moveRight && !VirtualInputManager.Instance.moveLeft) {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (VirtualInputManager.Instance.moveRight) {
                gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                animator.SetBool(TransitionParameter.move.ToString(), true);
            }

            if (VirtualInputManager.Instance.moveLeft) {
                gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                animator.SetBool(TransitionParameter.move.ToString(), true);
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
    }
}