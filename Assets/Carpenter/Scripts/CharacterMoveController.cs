using DefaultNamespace;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour {
    public float Speed;
    
    // Update is called once per frame
    void Update() {
        if (VirtualInputManager.Instance.moveRight && VirtualInputManager.Instance.moveLeft) {
            return;
        }

        if (VirtualInputManager.Instance.moveRight) {
            gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (VirtualInputManager.Instance.moveLeft) {
            gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}