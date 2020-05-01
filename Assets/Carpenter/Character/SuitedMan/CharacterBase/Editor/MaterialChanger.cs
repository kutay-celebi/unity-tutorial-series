using DefaultNamespace;
using UnityEditor;
using UnityEngine;

namespace Carpenter.Character.SuitedMan.CharacterBase.Editor {
    [CustomEditor(typeof(MoveController))]
    public class MaterialChanger : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            MoveController cc = (MoveController) target;
            if (GUILayout.Button("Change Material")) {
                cc.ChangeMaterial();
            }
        }
    }
}