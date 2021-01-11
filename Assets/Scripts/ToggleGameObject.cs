using UnityEngine;

public static class ToggleGameObject
{
    public static void Toggle(this GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
    public static void ToggleOtherGameObject(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}