using DefaultNamespace;
using UnityEditor;
using UnityEngine;

namespace Carpenter.Character.SuitedMan.CharacterBase.Editor {
    [CustomEditor(typeof(CharacterMoveController))]
    public class MaterialChanger : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            CharacterMoveController cc = (CharacterMoveController) target;
            if (GUILayout.Button("Change Material")) {
                cc.ChangeMaterial();
            }
        }
    }
}