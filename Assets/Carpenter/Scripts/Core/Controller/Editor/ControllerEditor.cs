using DefaultNamespace;
using DefaultNamespace.Controller;
using UnityEditor;
using UnityEngine;

namespace Carpenter.Scripts.Core.Controller.Editor {
    [CustomEditor(typeof(MoveController))]
    public class ControllerEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            MoveController o = (MoveController) target;

            if (GUILayout.Button("Setup Ragdoll Parts")) {
                o.SetRagdollParts();
            }
        }
    }
}