using UnityEngine;

namespace MenuBuilder.Configs
{
    public interface IPrefabInstantiator
    {
        GameObject InstantiatePrefab(GameObject objectToCreate, Transform parent);
    }
}