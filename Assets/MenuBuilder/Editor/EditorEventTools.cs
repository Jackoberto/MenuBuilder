using MenuBuilder.Configs;
using UnityEditor.Events;
using UnityEngine.Events;

namespace MenuBuilder.Editor
{
    public class EditorEventTools : IEventTools
    {
        public void AddBoolPersistentListener(UnityEvent unityEvent, UnityAction<bool> unityAction, bool state)
        {
            UnityEventTools.AddBoolPersistentListener(unityEvent, unityAction, state);
        }

        public void AddPersistentListener(UnityEvent unityEvent, UnityAction unityAction)
        {
            UnityEventTools.AddPersistentListener(unityEvent, unityAction);
        }
    }
}