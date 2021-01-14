using MenuBuilder.Configs;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace MenuBuilder
{
    public class Menu : MonoBehaviour
    {
        public Element[] menuElementConfigs = new Element[2];
        public string label;
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