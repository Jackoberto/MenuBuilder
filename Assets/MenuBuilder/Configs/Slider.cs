using System;
using UnityEngine;
using UnityEngine.UI;

namespace MenuBuilder.Configs
{
   [Serializable][CreateAssetMenu(menuName = "Menu Builder Assets/Slider Config")]
   public class Slider : Element
   {
      public Color sliderFillColor = new Color(1, 1, 1,1);
      public int sliderMinimumValue = 0;
      public int sliderMaximumValue = 1;
      private GameObject _slider;
      public override void Create(string name, Menu menu, string[] args){
         _slider = Instantiate(objectToCreate, menu.transform);
         _slider.name = name;
         _slider.GetComponent<UnityEngine.UI.Slider>().direction = UnityEngine.UI.Slider.Direction.LeftToRight;
         _slider.GetComponent<UnityEngine.UI.Slider>().minValue = sliderMinimumValue;
         _slider.GetComponent<UnityEngine.UI.Slider>().maxValue = sliderMaximumValue;
         _slider.GetComponent<UnityEngine.UI.Slider>().fillRect.GetComponent<Image>().color = sliderFillColor;
      }
      
      //TODO Change All Edit Time Instantiates To PrefabUtility.InstantiatePrefab
   }
}