using System;
using UnityEngine;
using UnityEngine.UI;

namespace MenuBuilder.Configs
{
    [Serializable]
    [CreateAssetMenu(menuName = "Menu Builder Assets/Text Config")]
    public class Text : Element
    {
        private GameObject _text;

        public override void Create(IPrefabInstantiator prefabInstantiator, IEventTools eventTools, string name, Menu menu, string[] args)
        {
            _text = prefabInstantiator.InstantiatePrefab(objectToCreate, menu.transform);
            if (!string.IsNullOrEmpty(name))
                _text.name = name;
            CheckAllArgs(args);
        }

        [ExtraOption("Ignores The Menu Layout")]
        private void IgnoreLayout()
        {
            _text.AddComponent<LayoutElement>().ignoreLayout = true;
        }
    }
}