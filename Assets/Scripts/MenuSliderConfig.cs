using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable][CreateAssetMenu]
public class MenuSliderConfig : MenuElementConfig
{
   public Color sliderFillColor = new Color(1, 1, 1,1);
   public int sliderMinimumValue = 0;
   public int sliderMaximumValue = 1;
   private GameObject _slider;
   public override void Create(string name, Menu menu, string[] args){
      _slider = Instantiate(objectToCreate, menu.transform);
      _slider.name = "Slider";
      _slider.GetComponent<Slider>().direction = Slider.Direction.LeftToRight;
      _slider.GetComponent<Slider>().minValue = sliderMinimumValue;
      _slider.GetComponent<Slider>().maxValue = sliderMaximumValue;
      _slider.GetComponent<Slider>().fillRect.GetComponent<Image>().color = sliderFillColor;
      base.Create(name, menu, args);
   }
}