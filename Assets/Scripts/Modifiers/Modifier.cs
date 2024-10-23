using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(Modifier), true)]
public class ModifierDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        VisualElement container = new VisualElement();
        PropertyField field = new PropertyField(property.FindPropertyRelative("value"), property.displayName);
        container.Add(field);

        return container;
    }
}

#endif

[System.Serializable]
public class Modifier
{
    public float value;

    public Modifier(float value = 0)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public static implicit operator float(Modifier v) => v.value;
}