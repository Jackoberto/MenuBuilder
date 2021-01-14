using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuBuild : Editor
{
    [MenuItem("GameObject/MenuBuilder", false, 0)]
    private static void CreateMenu()
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
        var allAssetPaths = AssetDatabase.FindAssets("t:"+ nameof(MenuElementConfig));
        var paths = allAssetPaths.Select(AssetDatabase.GUIDToAssetPath);
        menu.menuElementConfigs = paths.Select(AssetDatabase.LoadAssetAtPath<MenuElementConfig>).ToArray();
    }
}
