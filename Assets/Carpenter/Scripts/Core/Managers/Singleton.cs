using UnityEngine;

namespace DefaultNamespace.Managers {
    /**
     * For creating singleton object
     */
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        private static T _instance;

        public static T Instance {
            get {
                // search object instance.
                _instance = (T) FindObjectOfType(typeof(T));
                if (_instance == null) {
                    // create game object with this.
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                    obj.name  = typeof(T).ToString();
                }

                return _instance;
            }
        }
    }
}