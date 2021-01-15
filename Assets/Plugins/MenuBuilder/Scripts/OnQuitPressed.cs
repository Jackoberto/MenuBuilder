using UnityEngine;

namespace MenuBuilder
{
    public class OnQuitPressed : MonoBehaviour
    {
        public GameObject menuHolder;
        public GameObject confirmationBox;

        public void QuitToConfirmationBox()
        {
            menuHolder.SetActive(false);
            var instance = Instantiate(confirmationBox, menuHolder.transform.parent);
            instance.GetComponent<ConfirmationBox>().OnConfirmation += Quit;
            instance.GetComponent<ConfirmationBox>().OnCancelled += BackToMenu;
        }

        public void Quit()
        {
#if UNITY_STANDALONE
            Application.Quit();
#endif
        
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        public void BackToMenu()
        {
            menuHolder.SetActive(true);
        }
    }
}
