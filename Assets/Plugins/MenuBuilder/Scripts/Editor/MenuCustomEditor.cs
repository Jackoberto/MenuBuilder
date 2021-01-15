using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace MenuBuilder.Editor
{
    [CustomEditor(typeof(Menu))]
    public class MenuCustomEditor : UnityEditor.Editor
    {
        private int _index;
        private bool[] _optionsTicked = new bool[0];
        public override void OnInspectorGUI()
        {
            var menu = (Menu) target;
            DrawDefaultInspector();

            if (menu.menuElementConfigs.Length > 1)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Choose Element:");
                GUILayout.FlexibleSpace();
                var height = GUILayout.Height(20);
                var width = GUILayout.Width(Screen.width * 0.5f);
                menu.elementToCreate = Mathf.Clamp(Mathf.RoundToInt(GUILayout.HorizontalSlider(menu.elementToCreate, 0,
                        menu.menuElementConfigs.Length - 1, new GUILayoutOption[] {height, width})),
                    0, menu.menuElementConfigs.Length);
                GUILayout.FlexibleSpace();
                width = GUILayout.Width(Screen.width * 0.15f);
                GUILayout.Label("Element #" + menu.elementToCreate, width);
                GUILayout.EndHorizontal();
            }
            else menu.elementToCreate = 0;

            if (menu.menuElementConfigs.Length > 0 && menu.menuElementConfigs[menu.elementToCreate] != null)
            {
                var args = menu.menuElementConfigs[menu.elementToCreate].Arguments.ToList();
                args.Add("Standard");
                args.Reverse();
                var formattedArgs = new List<string>();
                foreach (var arg in args)
                {
                    formattedArgs.Add(SeparateCamelCase(arg));
                }
                var toolTips = menu.menuElementConfigs[menu.elementToCreate].Descriptions.ToList();
                toolTips.Add("Creates The Default Menu Element");
                toolTips.Reverse();
                if (menu.menuElementConfigs[menu.elementToCreate].canCombineArgs)
                {
                    if (_optionsTicked.Length != args.Count)
                        _optionsTicked = new bool[args.Count];
                    for (var i = 1; i < args.Count; i++)
                    {
                        _optionsTicked[i] = GUILayout.Toggle(_optionsTicked[i], new GUIContent(formattedArgs[i], toolTips[i]));
                    }
                }
                else
                {
                    _index = EditorGUILayout.Popup(
                        new GUIContent("Object Options", toolTips[_index]), _index, formattedArgs.ToArray());
                    _index = Mathf.Clamp(_index, 0, args.Count - 1);
                }

                var subString = $"{menu.menuElementConfigs[menu.elementToCreate].name}";
                var name = subString.Replace("Config", "");
                var buttonText = $"Create {name}";
                if (GUILayout.Button(buttonText))
                {
                    if (menu.menuElementConfigs[menu.elementToCreate].canCombineArgs)
                    {
                        menu.menuElementConfigs[menu.elementToCreate].Create(new EditorPrefabInstantiator(), new EditorEventTools(), menu.objectName, menu, ResolveTickedArgs(args));
                    }
                    else
                        menu.menuElementConfigs[menu.elementToCreate].Create(new EditorPrefabInstantiator(), new EditorEventTools(), menu.objectName, menu,
                            _index != 0 ? new[] {args[_index]} : new[] {""});
                }
            }
        }

        private string[] ResolveTickedArgs(IEnumerable<string> orgStrings)
        {
            return orgStrings.Where((t, i) => _optionsTicked[i]).ToArray();
        }
        
        public static string SeparateCamelCase(string org)
        {
            return Regex.Replace(org, @"(\B[A-Z]+?(?=[A-Z][^A-Z])|\B[A-Z]+?(?=[^A-Z]))", " $1");
        }
    }
}