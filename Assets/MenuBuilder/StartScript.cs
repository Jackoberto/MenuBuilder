using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuBuilder
{
    public class StartScript : MonoBehaviour
    {
        [Tooltip("Leave Empty To Use Scene Index Instead")]
        public string sceneToLoad = "";
        public int sceneIndex;
        public void LoadScene()
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
                SceneManager.LoadScene(sceneToLoad);
            else
                SceneManager.LoadScene(sceneIndex);
        }
    }
}