using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable][CreateAssetMenu]
public class MenuBackgroundConfig : MenuElementConfig 
{
    
    private GameObject _backgroundImage;
    /*
    public Vector2 dimensions = new Vector2(400, 400);
    public Sprite backgroundImage;
    public Color backgroundColor = new Color(0, 0, 0, 1);
    public Material backgroundMaterial;
    public bool raycastTarget;
    public Vector4 raycastPadding;
    public bool maskable;
    public Vector2 anchoredPos = new Vector2(0, 0);
    */
    public override void Create(string name, Menu menu, string[] args)
    {
        
        _backgroundImage = Instantiate(objectToCreate, menu.transform);
        _backgroundImage.name = name;
        _backgroundImage.transform.SetAsFirstSibling();
        base.Create(name, menu, args);
        
        /* GameObject image = new GameObject();
        image.transform.parent = menu.transform;
        image.name = menu.label;
        image.AddComponent<RectTransform>().sizeDelta = dimensions;
        image.AddComponent<LayoutElement>().ignoreLayout = true;
        var imageComponent = image.AddComponent<Image>();
        imageComponent.color = backgroundColor;
        imageComponent.sprite = backgroundImage;
        imageComponent.material = backgroundMaterial;
        imageComponent.raycastTarget = raycastTarget;
        imageComponent.raycastPadding = raycastPadding;
        imageComponent.maskable = maskable;
        imageComponent.rectTransform.anchoredPosition = anchoredPos;
        base.Create(name, menu, args); 
        */
    }
}