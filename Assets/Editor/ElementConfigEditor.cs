using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MenuElementConfig), true)]
public class ElementConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var elementConfig = (MenuElementConfig) target;
        DrawDefaultInspector();
        if (GUILayout.Button("Update All Elements"))
        {
            elementConfig.UpdateElements();
        }
    }
}
