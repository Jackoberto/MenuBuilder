using UnityEngine;

namespace MenuBuilder
{
    public class QuitScript : MonoBehaviour
    {
        public void Quit()
        {
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            Application.Quit();
#endif
        }
    }
}