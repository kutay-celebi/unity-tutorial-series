using System;
using System.Security.Cryptography;
using DefaultNamespace.Managers;
using UnityEngine;

namespace DefaultNamespace {
    public class VirtualInputManager : Singleton<VirtualInputManager> {
        public bool moveRight;
        public bool moveLeft;
        public bool jump;
    }
}