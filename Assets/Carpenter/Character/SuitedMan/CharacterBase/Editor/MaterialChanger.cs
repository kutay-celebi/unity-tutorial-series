using UnityEditor;
using UnityEngine;

namespace Carpenter.Character.SuitedMan.CharacterBase.Editor {
    [CustomEditor(typeof(CharacterController))]
    public class MaterialChanger : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            
            base.OnInspectorGUI();
        }
    }
}