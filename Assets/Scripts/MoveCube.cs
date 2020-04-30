using DefaultNamespace;
using UnityEngine;

public class MoveCube : MonoBehaviour {
    public float Speed;
    
    // Update is called once per frame
    void Update() {
        if (VirtualInputManager.instance.moveRight && VirtualInputManager.instance.moveLeft) {
            return;
        }

        if (VirtualInputManager.instance.moveRight) {
            this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (VirtualInputManager.instance.moveLeft) {
            this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}