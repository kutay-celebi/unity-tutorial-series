﻿using System;
using UnityEngine;

namespace DefaultNamespace {
    public class KeyboardInput : UnityEngine.MonoBehaviour {
        private void Update() {
            if (Input.GetKey(KeyCode.D)) {
                VirtualInputManager.Instance.moveRight = true;
            } else {
                VirtualInputManager.Instance.moveRight = false;
            }

            if (Input.GetKey(KeyCode.A)) {
                VirtualInputManager.Instance.moveLeft = true;
            } else {
                VirtualInputManager.Instance.moveLeft = false;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                VirtualInputManager.Instance.jump = true;
            } else {
                VirtualInputManager.Instance.jump = false;
            }

            if (Input.GetKey(KeyCode.Mouse0)) {
                VirtualInputManager.Instance.attack = true;
            } else {
                VirtualInputManager.Instance.attack = false;
            }
        }
    }
}