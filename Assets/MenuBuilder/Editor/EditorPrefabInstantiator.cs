using MenuBuilder.Configs;
using UnityEditor;
using UnityEngine;

namespace MenuBuilder.Editor
{
    public class EditorPrefabInstantiator : IPrefabInstantiator
    {
        public GameObject InstantiatePrefab(GameObject objectToCreate, Transform parent)
        {
            return PrefabUtility.InstantiatePrefab(objectToCreate, parent) as GameObject;
        }
    }
}