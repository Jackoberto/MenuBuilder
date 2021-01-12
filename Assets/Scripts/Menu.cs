using System;
using System.Collections.Generic;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public MenuElementConfig[] menuElementConfigs = new MenuElementConfig[2];
    public string label;
    public int menuButtonToRemove;
    [HideInInspector] public int elementToCreate;

    private void ButtonClick(GameObject otherGameObject)
    {
        otherGameObject.Toggle();
        foreach (var button in buttons)
        {
            if (otherGameObject.transform.parent == button.transform)
            {
                button.GetComponent<Image>().Toggle();
                button.GetComponentInChildren<Text>().Toggle();
            }
            else button.Toggle();
        }
    }

    public void RemoveButton()
    {
        DestroyImmediate(buttons[menuButtonToRemove]);
        buttons.RemoveAt(menuButtonToRemove);
    }

    /*private GameObject CreateSubMenu(Transform otherTransform)
    {
        GameObject subMenu = new GameObject {name = "Sub Menu " + label};
        subMenu.transform.parent = otherTransform;
        var rect = subMenu.AddComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        var menu = subMenu.AddComponent<Menu>();
        menu.currentConfig = currentConfig;
        subMenu.AddComponent<LayoutElement>().ignoreLayout = true;
        var verticalLayoutGroup = subMenu.AddComponent<VerticalLayoutGroup>();
        verticalLayoutGroup.childAlignment = TextAnchor.MiddleCenter;
        verticalLayoutGroup.childForceExpandHeight = false;
        subMenu.Toggle();
        menu.CreateBackButton();
        return subMenu;
    }*/

    private void OnValidate()
    {
        elementToCreate = Mathf.Clamp(elementToCreate, 0, menuElementConfigs.Length - 1);
    }
}

public enum MenuElements
{
    Button,
    Background,
    Slider,
    Dropdown,
}