using System.Collections.Generic;
using System.Linq;
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
                args.Add("Default");
                args.Reverse();
                var toolTips = menu.menuElementConfigs[menu.elementToCreate].Descriptions.ToList();
                toolTips.Add("Creates The Default Menu Element");
                toolTips.Reverse();
                if (menu.menuElementConfigs[menu.elementToCreate].canCombineArgs)
                {
                    if (_optionsTicked.Length != args.Count)
                        _optionsTicked = new bool[args.Count];
                    for (var i = 1; i < args.Count; i++)
                    {
                        _optionsTicked[i] = GUILayout.Toggle(_optionsTicked[i], new GUIContent(args[i], toolTips[i]));
                    }
                }
                else
                {
                    _index = EditorGUILayout.Popup(
                        new GUIContent(args[_index], toolTips[_index]), _index, args.ToArray());
                    _index = Mathf.Clamp(_index, 0, args.Count - 1);
                }

                var subString = $"{menu.menuElementConfigs[menu.elementToCreate].name}";
                var buttonText = $"Add {subString}";
                if (GUILayout.Button(buttonText))
                {
                    if (menu.menuElementConfigs[menu.elementToCreate].canCombineArgs)
                    {
                        menu.menuElementConfigs[menu.elementToCreate].Create(menu.objectName, menu, ResolveTickedArgs(args));
                    }
                    else
                        menu.menuElementConfigs[menu.elementToCreate].Create(menu.objectName, menu,
                            _index != 0 ? new[] {args[_index]} : new[] {""});
                }
            }
        }

        private string[] ResolveTickedArgs(IEnumerable<string> orgStrings)
        {
            return orgStrings.Where((t, i) => _optionsTicked[i]).ToArray();
        }
    }
}