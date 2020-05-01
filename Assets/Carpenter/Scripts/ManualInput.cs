﻿using UnityEngine;

namespace DefaultNamespace {
    public class ManualInput : MonoBehaviour {
        private MoveController _controller;

        private void Awake() {
            _controller = this.gameObject.GetComponent<MoveController>();
        }

        private void Update() {
            if (VirtualInputManager.Instance.moveRight) {
                _controller.moveRight = true;
            } else {
                _controller.moveRight = false;
            }


            if (VirtualInputManager.Instance.moveLeft) {
                _controller.moveLeft = true;
            } else {
                _controller.moveLeft = false;
            }
            
            if (Input.GetKeyDown(KeyCode.Space)) {
                _controller.jump = true;
            } else {
                _controller.jump = false;
            }
        }
    }
}