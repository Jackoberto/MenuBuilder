using System;
using UnityEngine;

namespace MenuBuilder.Configs
{
    [Serializable][CreateAssetMenu(menuName = "Menu Builder Assets/Background Config")]
    public class Background : Element 
    {
        private GameObject _backgroundImage;
        private GameObject _menuHolder;

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
            _backgroundImage.name = objectToCreate.name;
            _backgroundImage.transform.SetAsFirstSibling();
            _menuHolder = menu.gameObject;
            CheckAllArgs(args);
        
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
        [ExtraOption("Makes the background image be the same size as the menu")]
        private void SameSize()
        {
            _backgroundImage.GetComponent<RectTransform>().anchorMin = Vector2.zero;
            _backgroundImage.GetComponent<RectTransform>().anchorMax = Vector2.one;
            _backgroundImage.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        }
    }
}