using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(menuName = "Menu Builder Assets/Text Config")]
public class MenuTextConfig : MenuElementConfig
{
    private GameObject _text;

    public override void Create(string name, Menu menu, string[] args)
    {
        _text = Instantiate(objectToCreate, menu.transform);
        _text.name = name;
        _text.GetComponent<Text>().text = name;
        base.Create(name, menu, args);
    }

    [ExtraOption("Ignores The Menu Layout")]
    private void IgnoreLayout()
    {
        _text.AddComponent<LayoutElement>().ignoreLayout = true;
    }

    /*public Vector2 dimensions = new Vector2(100, 100);
    public Color fontColor = new Color(0, 0, 0, 1);
    public TextAnchor textAnchor = TextAnchor.MiddleCenter;
    public Font font;
    public int fontSize = 14;
    public bool resizeForBestFit;*/
    [HideInInspector] public bool initialized;
}