using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable][CreateAssetMenu]
public class MenuBackgroundConfig : MenuElementConfig {
    
    public Vector2 dimensions = new Vector2(400, 400);
    public Sprite backgroundImage;
    public Color backgroundColor = new Color(0, 0, 0, 1);
    public Material backgroundMaterial;
    public bool raycastTarget;
    public Vector4 raycastPadding;
    public bool maskable;
}
