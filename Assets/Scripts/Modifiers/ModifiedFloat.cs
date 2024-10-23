using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(ModifiedFloat), true)]
public class BaseValueDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        VisualElement container = new VisualElement();
        PropertyField field = new PropertyField(property.FindPropertyRelative("_baseValue"), property.displayName);
        container.Add(field);

        return container;
    }
}

#endif

[System.Serializable]
public class ModifiedFloat
{
    [SerializeField] protected float _baseValue;

    protected List<Modifier> modifiers = new List<Modifier>();

    Func<float, float, float> operation;

    public event Action<Modifier> OnModifierAdded;
    public event Action<Modifier> OnModifierRemoved;
    public event Action OnModifierChanged;

    #region Getter & Setter

    public float Value => BaseValue + Bonus;
    public float BaseValue => _baseValue;
    public float Bonus
    {
        get
        {
            float bonus = 0;
            foreach (var modifier in modifiers)
                if (modifier != null)
                    bonus = operation(bonus, modifier.value);
            return bonus;
        }
    }

    #endregion

    #region Constructors

    public ModifiedFloat()
    {

    }

    public ModifiedFloat(float baseValue) : this(baseValue, (a, b) => a + b)
    {

    }

    public ModifiedFloat(float baseValue, Func<float, float, float> operation)
    {
        _baseValue = baseValue;
        this.operation = operation;
    }

    #endregion

    public void AddModifier(Modifier modifier)
    {
        if (modifier == null) return;

        modifiers.Add(modifier);

        OnModifierAdded?.Invoke(modifier);
        OnModifierChanged?.Invoke();
    }

    public void RemoveModifier(Modifier modifier)
    {
        if (modifiers.Remove(modifier))
        {
            OnModifierRemoved?.Invoke(modifier);
            OnModifierChanged?.Invoke();
        }
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator float(ModifiedFloat v) => v.Value;
}