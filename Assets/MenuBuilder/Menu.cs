using MenuBuilder.Configs;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace MenuBuilder
{
    public class Menu : MonoBehaviour
    {
        public Element[] menuElementConfigs = new Element[2];
        [Space] [Header("Write the objects name")]
        public string objectName;
        [HideInInspector] public int elementToCreate;

        public void ToggleThis()
        {
            var allButtons = GetComponentsInChildren<Button>(true);
            foreach (var button in allButtons)
            {
                if (button.transform.parent == transform)
                {
                    button.gameObject.SetActive(!button.gameObject.activeSelf);
                }
            }
        }

        private void OnValidate()
        {
            elementToCreate = Mathf.Clamp(elementToCreate, 0, menuElementConfigs.Length - 1);
        }
    }
}