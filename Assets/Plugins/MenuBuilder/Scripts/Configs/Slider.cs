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
      private string _text;

      protected override void OnValidate()
      {
         base.OnValidate();
         canCombineArgs = true;
      }

      public override void Create(IPrefabInstantiator prefabInstantiator, IEventTools eventTools, string name, Menu menu, string[] args){
         _slider = prefabInstantiator.InstantiatePrefab(objectToCreate, menu.transform);
         if (!string.IsNullOrEmpty(name))
            _slider.name = name;
         _text = name;
         _slider.GetComponent<UnityEngine.UI.Slider>().direction = UnityEngine.UI.Slider.Direction.LeftToRight;
         _slider.GetComponent<UnityEngine.UI.Slider>().minValue = sliderMinimumValue;
         _slider.GetComponent<UnityEngine.UI.Slider>().maxValue = sliderMaximumValue;
         _slider.GetComponent<UnityEngine.UI.Slider>().fillRect.GetComponent<Image>().color = sliderFillColor;
         CheckAllArgs(args);
      }
      
      [ExtraOption("Ignores The Menu Layout")]
      private void IgnoreLayout()
      {
         _slider.AddComponent<LayoutElement>().ignoreLayout = true;
      }

      [ExtraOption("Adds A Text Above The Slider")]
      private void AddText()
      {
         var gameObject = new GameObject();
         gameObject.transform.parent = _slider.transform;
         gameObject.transform.localPosition = new Vector3(0, 15);
         gameObject.name = !string.IsNullOrEmpty(_text) ? _text : "Text";
         var text = gameObject.AddComponent<UnityEngine.UI.Text>();
         text.raycastTarget = false;
         text.alignment = TextAnchor.MiddleCenter;
         text.text = !string.IsNullOrEmpty(_text) ? _text : "Add Your Text";
      }
   }
}