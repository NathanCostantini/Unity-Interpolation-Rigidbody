using System;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(RangeFloat))]
public class RangeValueDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        VisualElement container = new VisualElement();
        PropertyField field = new PropertyField(property.FindPropertyRelative("maxValue"), property.displayName);
        container.Add(field);

        return container;
    }
}

#endif

[System.Serializable]
public class RangeFloat
{
    [SerializeField] float maxValue;

    public float value { get; private set; }
    public float MaxValue => maxValue;
    public float Percentage => value / maxValue;

    public event Action<float> OnAdded;
    public event Action<float> OnRemoved;
    public event Action<float> OnChanged;
    public event Action OnMaxValue;
    public event Action OnMinValue;

    #region Constructors

    public RangeFloat() : this(100)
    {

    }

    public RangeFloat(float maxValue) : this(new ModifiedFloat(maxValue))
    {

    }

    public RangeFloat(ModifiedFloat maxValue)
    {
        this.maxValue = maxValue;
    }

    #endregion

    public void SetToMaxValue()
    {
        SetValue(maxValue);
    }

    public void Add(float a)
    {
        float previousValue = value;

        SetValue(value + a);

        float delta = value - previousValue;

        if (delta != 0)
            OnAdded?.Invoke(delta);
    }

    public void Remove(float a)
    {
        float previousValue = value;

        SetValue(value - a);

        float delta = Mathf.Abs(value - previousValue);

        if (delta != 0)
            OnRemoved?.Invoke(delta);
    }

    public void SetValue(float a)
    {
        float previousValue = value;

        value = a;

        value = Mathf.Clamp(value, 0, maxValue);

        if (value >= maxValue) OnMaxValue?.Invoke();
        if (value <= 0) OnMinValue?.Invoke();

        float delta = value - previousValue;

        if (delta != 0)
            OnChanged?.Invoke(value);
    }

    public static implicit operator float(RangeFloat v) => v.value;
}
