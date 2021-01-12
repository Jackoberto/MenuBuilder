﻿using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable][CreateAssetMenu]
public class MenuButtonConfig : MenuElementConfig
{
    private void Awake()
    {
        if (initialized) return;
        buttonColorBlock.highlightedColor = new Color(1, 1, 1, 1);
        buttonColorBlock.normalColor = new Color(1, 1, 1, 1);
        buttonColorBlock.pressedColor = new Color(0.78f, 0.78f, 0.78f, 1);
        buttonColorBlock.selectedColor = new Color(0.96f, 0.96f, 0.96f, 1);
        buttonColorBlock.disabledColor = new Color(0.78f, 0.78f, 0.78f, 0.5f);
        buttonColorBlock.fadeDuration = 0.1f;
        buttonColorBlock.colorMultiplier = 1;
        font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        initialized = true;
    }

    public override void Create(string name, Menu menu)
    {
        GameObject button = new GameObject();
        button.transform.parent = menu.transform;
        GameObject textObject = new GameObject();
        textObject.transform.parent = button.transform;
        button.name = menu.label;
        button.AddComponent<RectTransform>().sizeDelta = dimensions;
        var buttonComponent = button.AddComponent<Button>();
        var image = button.AddComponent<Image>();
        var textComponent = textObject.AddComponent<Text>();
        image.type = Image.Type.Sliced;
        image.color = imageColor;
        image.sprite = this.image;
        buttonComponent.colors = buttonColorBlock;
        textObject.GetComponent<RectTransform>().sizeDelta = button.GetComponent<RectTransform>().sizeDelta;
        textComponent.font = font;
        textComponent.fontSize = fontSize;
        textComponent.text = menu.label;
        textComponent.alignment = textAnchor;
        textComponent.resizeTextForBestFit = resizeForBestFit;
        textComponent.color = fontColor;
    }

    public Vector2 dimensions = new Vector2(100, 100);
    public Color imageColor = new Color(1, 1, 1,1);
    public ColorBlock buttonColorBlock;
    public Sprite image;
    public Color fontColor = new Color(0, 0, 0,1);
    public TextAnchor textAnchor = TextAnchor.MiddleCenter;
    public Font font;
    public int fontSize = 14;
    public bool resizeForBestFit;
    [HideInInspector] public bool initialized;
}

public class MenuElementConfig : ScriptableObject
{
    public virtual void Create(string name, Menu menu)
    {
        
    }
}
