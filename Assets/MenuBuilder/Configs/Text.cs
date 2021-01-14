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

        public override void Create(string name, Menu menu, string[] args)
        {
            _text = Instantiate(objectToCreate, menu.transform);
            _text.name = name;
            _text.GetComponent<UnityEngine.UI.Text>().text = name;
            CheckAllArgs(args);
        }

        [ExtraOption("Ignores The Menu Layout")]
        private void IgnoreLayout()
        {
            _text.AddComponent<LayoutElement>().ignoreLayout = true;
        }
        
        //TODO Change All Edit Time Instantiates To PrefabUtility.InstantiatePrefab
    }
}