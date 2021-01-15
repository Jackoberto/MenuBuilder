using System.Collections.Generic;
using MenuBuilder.Configs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MenuBuilder
{
    public class Menu : MonoBehaviour
    {
        [Tooltip("Add Scriptable Objects To This List")]
        public Element[] menuElementConfigs = new Element[2];
        [Space] [Header("Write the objects name")]
        public string objectName;
        [HideInInspector] public int elementToCreate;

        public void ToggleThis()
        {
            var allUIBehaviours = GetComponentsInChildren<UIBehaviour>(true);
            var allGameObjects = new Dictionary<int, GameObject>();
            foreach (var UIBehaviour in allUIBehaviours)
            {
                if (UIBehaviour.transform.parent != transform) continue;
                if (!allGameObjects.ContainsKey(UIBehaviour.gameObject.GetInstanceID()))
                    allGameObjects.Add(UIBehaviour.gameObject.GetInstanceID(), UIBehaviour.gameObject);
            }

            foreach (var pair in allGameObjects)
            {
                pair.Value.gameObject.SetActive(!pair.Value.gameObject.activeSelf);
            }
        }

        private void OnValidate()
        {
            elementToCreate = Mathf.Clamp(elementToCreate, 0, menuElementConfigs.Length - 1);
        }
    }
}