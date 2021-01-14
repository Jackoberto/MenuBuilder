using System;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;

[Serializable][CreateAssetMenu]
public class MenuButtonConfig : MenuElementConfig
{
    public GameObject submenu;
    private GameObject _button;
    private Menu _menu;
    /*public override void Awake()
    {
        base.Awake();
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

    public override void Create(string name, Menu menu, string[] args)
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
        AddMenuElement(button);
        base.Create(name, menu, args);
    }

    public override void ApplyUpdate(MenuElement menuElement)
    {
        Debug.Log(MethodBase.GetCurrentMethod().ToString());
        menuElement.GetComponent<RectTransform>().sizeDelta = dimensions;
    }*/

    public override void Create(string name, Menu menu, string[] args)
    {
        _button = Instantiate(objectToCreate, menu.transform);
        _button.name = name;
        _button.GetComponentInChildren<Text>().text = name;
        _menu = menu;
        base.Create(name, menu, args);
    }

    [ExtraOption("Adds The Start Script To The Button Press")]
    private void AddStart()
    {
        var start = _button.AddComponent<StartScript>();
        UnityEventTools.AddPersistentListener(_button.GetComponent<Button>().onClick, start.LoadScene);
    }
    
    [ExtraOption("Adds A Sub Menu That Opens On Button Press")]
    private void AddSubMenu()
    {
        var newSubmenu = Instantiate(submenu, _menu.transform);
        var backButton = Instantiate(objectToCreate, newSubmenu.transform);
        backButton.GetComponentInChildren<Text>().text = "Back";
        UnityEventTools.AddPersistentListener(_button.GetComponent<Button>().onClick, _menu.ToggleThis);
        UnityEventTools.AddPersistentListener(backButton.GetComponent<Button>().onClick, _menu.ToggleThis);
        UnityEventTools.AddBoolPersistentListener(_button.GetComponent<Button>().onClick, newSubmenu.gameObject.SetActive, true);
        UnityEventTools.AddBoolPersistentListener(backButton.GetComponent<Button>().onClick, newSubmenu.gameObject.SetActive, false);
        newSubmenu.transform.position = _menu.transform.position;
        newSubmenu.SetActive(false);
    }

    [ExtraOption("Adds The Quit Script To The Button Press")]
    private void AddQuit()
    {
        var quit = _button.AddComponent<QuitScript>();
        UnityEventTools.AddPersistentListener(_button.GetComponent<Button>().onClick, quit.Quit);
    }
    
    /*public Vector2 dimensions = new Vector2(100, 100);
    public Color imageColor = new Color(1, 1, 1,1);
    public ColorBlock buttonColorBlock;
    public Sprite image;
    public Color fontColor = new Color(0, 0, 0,1);
    public TextAnchor textAnchor = TextAnchor.MiddleCenter;
    public Font font;
    public int fontSize = 14;
    public bool resizeForBestFit;*/
    [HideInInspector] public bool initialized;
}