using System;
using UnityEngine;

namespace DefaultNamespace {
    public class KeyboardInput : UnityEngine.MonoBehaviour {
        private void Update() {
            if (Input.GetKey(KeyCode.D)) {
                VirtualInputManager.instance.moveRight = true;
            } else {
                VirtualInputManager.instance.moveRight = false;
            }

            if (Input.GetKey(KeyCode.A)) {
                VirtualInputManager.instance.moveLeft = true;
            } else {
                VirtualInputManager.instance.moveLeft = false;
            }
                
        }
    }
}