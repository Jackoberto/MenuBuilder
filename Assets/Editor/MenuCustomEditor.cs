using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Menu))]
public class MenuCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var menu = (Menu) target;
        DrawDefaultInspector();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Choose Element:");
        GUILayout.FlexibleSpace();
        var height = GUILayout.Height(20);
        var width = GUILayout.Width(Screen.width * 0.5f);
        menu.elementToCreate = Mathf.Clamp(Mathf.RoundToInt(GUILayout.HorizontalSlider(menu.elementToCreate, 0, menu.menuElementConfigs.Length - 1, 
            new GUILayoutOption[]{height, width})
        ), 0, menu.menuElementConfigs.Length);
        GUILayout.FlexibleSpace();
        width = GUILayout.Width(Screen.width * 0.15f);
        GUILayout.Label("Element #" + menu.elementToCreate, width);
        GUILayout.EndHorizontal();
        if (GUILayout.Button($"Add {menu.menuElementConfigs[menu.elementToCreate].name}"))
        {
            menu.menuElementConfigs[menu.elementToCreate].Create(menu.label, menu);
        }
        if (GUILayout.Button("Remove Button"))
        {
            menu.RemoveButton();
        }
    }
}