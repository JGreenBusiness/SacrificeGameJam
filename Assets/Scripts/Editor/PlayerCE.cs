using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.Editor
{
    [CustomEditor(typeof(Player))]
    public class PlayerCE : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Add Survivor"))
            {
                ((Player)target).AddFollower();
            }
            if (GUILayout.Button("Remove Survivor"))
            {
                ((Player)target).RemoveFollower();
            }
        }
    }
}