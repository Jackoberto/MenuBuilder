using System;
using UnityEditor;
using UnityEngine;

namespace MenuBuilder.Configs
{
    [Serializable][CreateAssetMenu(menuName = "Menu Builder Assets/Background Config")]
    public class Background : Element 
    {
        private GameObject _backgroundImage;
        public override void Create(string name, Menu menu, string[] args)
        {
        
            _backgroundImage = PrefabUtility.InstantiatePrefab(objectToCreate, menu.transform) as GameObject;
            _backgroundImage.name = objectToCreate.name;
            _backgroundImage.transform.SetAsFirstSibling();
            CheckAllArgs(args);
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