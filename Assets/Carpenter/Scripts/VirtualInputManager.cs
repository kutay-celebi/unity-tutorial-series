using DefaultNamespace.Managers;

namespace DefaultNamespace {
    public class VirtualInputManager : Singleton<VirtualInputManager> {
        public bool moveRight;
        public bool moveLeft;
        public bool jump;
        public bool attack;
    }
}