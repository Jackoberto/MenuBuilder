using UnityEngine.Events;

namespace MenuBuilder.Configs
{
    public interface IEventTools
    {
        void AddBoolPersistentListener(UnityEvent unityEvent, UnityAction<bool> unityAction, bool state);
        void AddPersistentListener(UnityEvent unityEvent, UnityAction unityAction);
    }
}