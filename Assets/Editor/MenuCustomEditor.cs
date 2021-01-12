﻿using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Menu))]
public class MenuCustomEditor : Editor
{
    private int _index;
    private bool[] _optionsTicked = new bool[0];
    public override void OnInspectorGUI()
    {
        var menu = (Menu) target;
        DrawDefaultInspector();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Choose Element:");
        GUILayout.FlexibleSpace();
        var height = GUILayout.Height(20);
        var width = GUILayout.Width(Screen.width * 0.5f);
        menu.elementToCreate = Mathf.Clamp(Mathf.RoundToInt(GUILayout.HorizontalSlider(menu.elementToCreate, 0, 
            menu.menuElementConfigs.Length - 1, new GUILayoutOption[]{height, width})),
            0, menu.menuElementConfigs.Length);
        GUILayout.FlexibleSpace();
        width = GUILayout.Width(Screen.width * 0.15f);
        GUILayout.Label("Element #" + menu.elementToCreate, width);
        GUILayout.EndHorizontal();
        var args = menu.menuElementConfigs[menu.elementToCreate].Arguments.ToList();
        args.Add("Default");
        args.Reverse();
        if (menu.menuElementConfigs[menu.elementToCreate].canCombineArgs)
        {
           if (_optionsTicked.Length != args.Count) 
               _optionsTicked = new bool[args.Count];
           for (var i = 1; i < args.Count; i++)
           {
               _optionsTicked[i] = GUILayout.Toggle(_optionsTicked[i], args[i]);
           } 
        }
        else
        {
            _index = EditorGUILayout.Popup(_index, args.ToArray());
            _index = Mathf.Clamp(_index, 0, args.Count - 1); 
        }
        
        

        if (menu.menuElementConfigs.Length > 0 && menu.menuElementConfigs[menu.elementToCreate] != null)
        {
            var subString = $"{menu.menuElementConfigs[menu.elementToCreate].name}";
            var buttonText = $"Add {subString}";
            if (GUILayout.Button(buttonText))
            {
                if (menu.menuElementConfigs[menu.elementToCreate].canCombineArgs)
                {
                    menu.menuElementConfigs[menu.elementToCreate].Create(menu.label, menu, ResolveTickedArgs(args));
                }
                menu.menuElementConfigs[menu.elementToCreate].Create(menu.label, menu,
                    _index != 0 ? new [] {args[_index]} : new []{""});
            }
        }
        if (GUILayout.Button("Remove Button"))
        {
            menu.RemoveButton();
        }
    }

    private string[] ResolveTickedArgs(IEnumerable<string> orgStrings)
    {
        return orgStrings.Where((t, i) => _optionsTicked[i]).ToArray();
    }
}