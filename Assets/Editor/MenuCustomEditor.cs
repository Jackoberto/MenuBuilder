using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Menu))]
public class MenuCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var menu = (Menu) target;
        DrawDefaultInspector();
        if (GUILayout.Button("Add Button"))
        {
            menu.CreateButton();
        }
        if (GUILayout.Button("Remove Button"))
        {
            menu.RemoveButton();
        }
    }
}