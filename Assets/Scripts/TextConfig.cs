using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable][CreateAssetMenu]
public class TextConfig : MenuElementConfig
{
     private void Awake()
    {
        if (initialized) return;

        font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        initialized = true;
    }

    public override void Create(string name, Menu menu)
    {
        GameObject textObject = new GameObject();
        textObject.name = menu.label;
        textObject.AddComponent<RectTransform>().sizeDelta = dimensions;
        var textComponent = textObject.AddComponent<Text>();
        textObject.GetComponent<RectTransform>().sizeDelta = textObject.GetComponent<RectTransform>().sizeDelta;
        textComponent.font = font;
        textComponent.fontSize = fontSize;
        textComponent.text = menu.label;
        textComponent.alignment = textAnchor;
        textComponent.resizeTextForBestFit = resizeForBestFit;
        textComponent.color = fontColor;
    }

    public Vector2 dimensions = new Vector2(100, 100);
    public Color fontColor = new Color(0, 0, 0,1);
    public TextAnchor textAnchor = TextAnchor.MiddleCenter;
    public Font font;
    public int fontSize = 14;
    public bool resizeForBestFit;
    [HideInInspector] public bool initialized;
}
