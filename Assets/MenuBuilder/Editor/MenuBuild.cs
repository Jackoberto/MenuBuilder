using System.Linq;
using MenuBuilder.Configs;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Button = MenuBuilder.Configs.Button;

namespace MenuBuilder.Editor
{
    public class MenuBuild : UnityEditor.Editor
    {
        [MenuItem("GameObject/MenuBuilder", false, 0)]
        private static GameObject CreateMenu()
        {
            var canvas = FindObjectOfType<Canvas>();
            if (canvas == null)
            {
                var myGO = new GameObject("Canvas");
                canvas = myGO.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                myGO.AddComponent<CanvasScaler>();
                myGO.AddComponent<GraphicRaycaster>();
                myGO.layer = 5;
            }
            var menuBuilder = new GameObject("Menu Builder");
            menuBuilder.transform.parent = canvas.transform;
            var rectTransform = menuBuilder.AddComponent<RectTransform>();
            var menu = menuBuilder.AddComponent<Menu>();
            var verticalLayoutGroup = menuBuilder.AddComponent<VerticalLayoutGroup>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.anchoredPosition = Vector2.zero;
            verticalLayoutGroup.childForceExpandHeight = false;
            verticalLayoutGroup.childAlignment = TextAnchor.MiddleCenter;
            var allAssetPaths = AssetDatabase.FindAssets("t:"+ nameof(Element));
            var paths = allAssetPaths.Select(AssetDatabase.GUIDToAssetPath);
            menu.menuElementConfigs = paths.Select(AssetDatabase.LoadAssetAtPath<Element>).ToArray();
            return menuBuilder;
        }

        [MenuItem("GameObject/MenuBuilderTemplates/Main Menu", false, 0)]
        private static void CreateMainMenu()
        {
            var menu = CreateMenu();
            var allAssetPaths = AssetDatabase.FindAssets("Default Button Config");
            var paths = allAssetPaths.Select(AssetDatabase.GUIDToAssetPath).ToList();
            var button = paths.Select(AssetDatabase.LoadAssetAtPath<Button>).ToArray()[0];
            button.Create("Start", menu.GetComponent<Menu>(), new []{"AddStart"});
            button.Create("Options", menu.GetComponent<Menu>(), new []{"AddSubMenu"});
            button.Create("Quit", menu.GetComponent<Menu>(), new []{"AddQuit"});
        }
    }
}
