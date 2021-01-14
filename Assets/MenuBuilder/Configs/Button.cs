using System;
using UnityEditor;
using UnityEditor.Events;
using UnityEngine;

namespace MenuBuilder.Configs
{
    [Serializable][CreateAssetMenu(menuName = "Menu Builder Assets/Button Config")]
    public class Button : Element
    {
        public GameObject submenu;
        public GameObject confirmationBox;
        private GameObject _button;
        private Menu _menu;

        public override void Create(string name, Menu menu, string[] args)
        {
            _button = PrefabUtility.InstantiatePrefab(objectToCreate, menu.transform) as GameObject;
            _button.name = objectToCreate.name;
            _button.GetComponentInChildren<UnityEngine.UI.Text>().text = name;
            _menu = menu;
            CheckAllArgs(args);
        }

        [ExtraOption("Adds The Start Script To The Button Press")]
        private void AddStart()
        {
            var start = _button.AddComponent<StartScript>();
            UnityEventTools.AddPersistentListener(_button.GetComponent<UnityEngine.UI.Button>().onClick, start.LoadScene);
        }
    
        [ExtraOption("Adds A Sub Menu That Opens On Button Press")]
        private void AddSubMenu()
        {
            var newSubmenu = Instantiate(submenu, _menu.transform);
            var backButton = Instantiate(objectToCreate, newSubmenu.transform);
            backButton.GetComponentInChildren<UnityEngine.UI.Text>().text = "Back";
            UnityEventTools.AddPersistentListener(_button.GetComponent<UnityEngine.UI.Button>().onClick, _menu.ToggleThis);
            UnityEventTools.AddPersistentListener(backButton.GetComponent<UnityEngine.UI.Button>().onClick, _menu.ToggleThis);
            UnityEventTools.AddBoolPersistentListener(_button.GetComponent<UnityEngine.UI.Button>().onClick, newSubmenu.gameObject.SetActive, true);
            UnityEventTools.AddBoolPersistentListener(backButton.GetComponent<UnityEngine.UI.Button>().onClick, newSubmenu.gameObject.SetActive, false);
            newSubmenu.transform.position = _menu.transform.position;
            newSubmenu.SetActive(false);
        }

        [ExtraOption("Adds The Quit Script To The Button Press")]
        private void AddQuit()
        {
            _button.name = "Quit button";
            var quit = _button.AddComponent<QuitScript>();
            UnityEventTools.AddPersistentListener(_button.GetComponent<UnityEngine.UI.Button>().onClick, quit.Quit);
        }

        [ExtraOption("Adds The Quit Script With A Confirmation Popup To The Button Press")]
        private void AddQuitWithConfirmation()
        {
            _button.name = "Quit button";
            var quit = _button.AddComponent<OnQuitPressed>();
            quit.confirmationBox = confirmationBox;
            quit.menuHolder = _menu.gameObject;
            UnityEventTools.AddPersistentListener(_button.GetComponent<UnityEngine.UI.Button>().onClick, quit.QuitToConfirmationBox);
        }
        
        //TODO Change All Edit Time Instantiates To PrefabUtility.InstantiatePrefab
    }
}