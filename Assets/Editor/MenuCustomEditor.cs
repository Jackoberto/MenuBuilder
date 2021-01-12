using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Menu))]
public class MenuCustomEditor : Editor
{
    private int _index;
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
        var args = menu.menuElementConfigs[menu.elementToCreate].Arguments.ToList();
        args.Add("Default");
        args.Reverse();
        _index = EditorGUILayout.Popup(_index, args.ToArray());
        _index = Mathf.Clamp(_index, 0, args.Count - 1);

        if (menu.menuElementConfigs.Length > 0 && menu.menuElementConfigs[menu.elementToCreate] != null)
        {
            var subString = $"{menu.menuElementConfigs[menu.elementToCreate].name}";
            var buttonText = $"Add {subString}";
            if (GUILayout.Button(buttonText))
            {
                menu.menuElementConfigs[menu.elementToCreate].Create(menu.label, menu,
                    _index != 0 ? args[_index] : "");
            }
        }
        if (GUILayout.Button("Remove Button"))
        {
            menu.RemoveButton();
        }
    }
}