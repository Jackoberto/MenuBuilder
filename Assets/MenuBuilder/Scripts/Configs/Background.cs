using System;
using UnityEngine;

namespace MenuBuilder.Configs
{
    [Serializable][CreateAssetMenu(menuName = "Menu Builder Assets/Background Config")]
    public class Background : Element 
    {
        private GameObject _backgroundImage;
        public override void Create(IPrefabInstantiator prefabInstantiator, IEventTools eventTools, string name, Menu menu, string[] args)
        {
            _backgroundImage = prefabInstantiator.InstantiatePrefab(objectToCreate, menu.transform);
            _backgroundImage.name = objectToCreate.name;
            if (!string.IsNullOrEmpty(name))
                _backgroundImage.name = name;
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