using UnityEngine;

public static class ToggleExtension
{
    public static void Toggle(this GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public static void Toggle(this Behaviour behaviour)
    {
        behaviour.enabled = !behaviour.enabled;
    }
    
    public static void Toggle(this Renderer renderer)
    {
        renderer.enabled = !renderer.enabled;
    }

    public static void Toggle(this Collider collider)
    {
        collider.enabled = !collider.enabled;
    }

    public static void ToggleOtherGameObject(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}