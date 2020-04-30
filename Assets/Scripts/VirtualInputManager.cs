using System;
using System.Security.Cryptography;
using UnityEngine;

namespace DefaultNamespace {
    public class VirtualInputManager : MonoBehaviour {

        public static VirtualInputManager instance = null;

        public bool moveRight;
        public bool moveLeft;
        
        
        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(this.gameObject);
            }
        }
    }
}