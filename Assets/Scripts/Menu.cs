using System.Collections.Generic;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public MenuButton currentConfig;
    public int menuButtonToRemove;

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

    private GameObject CreateSubMenu(Transform otherTransform)
    {
        GameObject subMenu = new GameObject {name = "Sub Menu " + currentConfig.label};
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
    }
    
    public void CreateButton()
    {
        var button = CreateButton(currentConfig.menuButtonConfig, currentConfig);
        buttons.Add(button);
    }

    private void CreateBackButton()
    {
        var button = CreateBackButton(currentConfig.menuButtonConfig, currentConfig);
        buttons.Add(button);
    }
    
    private GameObject CreateBackButton(MenuButtonConfig menuButtonConfig, MenuButton menuButton){

        GameObject button = new GameObject();
        button.transform.parent = transform;
        GameObject textObject = new GameObject();
        textObject.transform.parent = button.transform;
        button.name = "Back";
        button.AddComponent<RectTransform>().sizeDelta = currentConfig.menuButtonConfig.dimensions;
        var buttonComponent = button.AddComponent<Button>();
        var image = button.AddComponent<Image>();
        var textComponent = textObject.AddComponent<Text>();
        image.type = Image.Type.Sliced;
        image.color = menuButtonConfig.imageColor;
        image.sprite = menuButton.image;
        buttonComponent.colors = menuButtonConfig.buttonColorBlock;
        textObject.GetComponent<RectTransform>().sizeDelta = button.GetComponent<RectTransform>().sizeDelta;
        textComponent.font = menuButtonConfig.font;
        textComponent.fontSize = menuButtonConfig.fontSize;
        textComponent.text = "Back";
        textComponent.alignment = menuButtonConfig.textAnchor;
        textComponent.resizeTextForBestFit = menuButtonConfig.resizeForBestFit;
        textComponent.color = menuButtonConfig.fontColor;
        UnityEventTools.AddObjectPersistentListener(button.GetComponent<Button>().onClick, GetComponentInParent<Menu>().ButtonClick, CreateSubMenu(button.transform));
        return button;
    }

    private GameObject CreateButton(MenuButtonConfig menuButtonConfig, MenuButton menuButton){

        GameObject button = new GameObject();
        button.transform.parent = transform;
        GameObject textObject = new GameObject();
        textObject.transform.parent = button.transform;
        button.name = menuButton.label;
        button.AddComponent<RectTransform>().sizeDelta = currentConfig.menuButtonConfig.dimensions;
        var buttonComponent = button.AddComponent<Button>();
        var image = button.AddComponent<Image>();
        var textComponent = textObject.AddComponent<Text>();
        image.type = Image.Type.Sliced;
        image.color = menuButtonConfig.imageColor;
        image.sprite = menuButton.image;
        buttonComponent.colors = menuButtonConfig.buttonColorBlock;
        textObject.GetComponent<RectTransform>().sizeDelta = button.GetComponent<RectTransform>().sizeDelta;
        textComponent.font = menuButtonConfig.font;
        textComponent.fontSize = menuButtonConfig.fontSize;
        textComponent.text = menuButton.label;
        textComponent.alignment = menuButtonConfig.textAnchor;
        textComponent.resizeTextForBestFit = menuButtonConfig.resizeForBestFit;
        textComponent.color = menuButtonConfig.fontColor;
        if (currentConfig.createSubMenu)
            UnityEventTools.AddObjectPersistentListener(button.GetComponent<Button>().onClick, ButtonClick, CreateSubMenu(button.transform));
        return button;
    }
}