using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[Serializable][CreateAssetMenu]
public class MenuSliderConfig : MenuElementConfig
{
   public override void Awake(){
      base.Awake();
      if (initialized) return;
      sliderColorBlock.highlightedColor = new Color(1, 1, 1, 1);
      sliderColorBlock.normalColor = new Color(1, 1, 1, 1);
      sliderColorBlock.pressedColor = new Color(0.78f, 0.78f, 0.78f, 1);
      sliderColorBlock.selectedColor = new Color(0.96f, 0.96f, 0.96f, 1);
      sliderColorBlock.disabledColor = new Color(0.78f, 0.78f, 0.78f, 0.5f);
      sliderColorBlock.fadeDuration = 0.1f;
      sliderColorBlock.colorMultiplier = 1;
      initialized = true;
   }
   public override void Create(string name, Menu menu, string[] args){

      GameObject slider = new GameObject("Slider");
      slider.transform.parent = menu.transform;
      slider.GetComponent<Slider>().direction = Slider.Direction.LeftToRight;
      slider.GetComponent<Slider>().minValue = sliderMinimumValue;
      slider.GetComponent<Slider>().maxValue = sliderMaximumValue;

      base.Create(name, menu, args);
   }
   public Vector2 dimensions = new Vector2(160, 20);
   public Color sliderFillColor = new Color(1, 1, 1,1);
   public ColorBlock sliderColorBlock;
   public Sprite backgroundImage;
   public Sprite fillImage;
   public Sprite sliderHandleImage;
   public Slider.Direction sliderDirection = Slider.Direction.LeftToRight;
   public int sliderMinimumValue = 0;
   public int sliderMaximumValue = 1;
   [HideInInspector] public bool initialized;
}
