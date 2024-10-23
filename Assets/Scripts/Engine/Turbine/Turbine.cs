using UnityEngine;

public class Turbine : MonoBehaviour
{
    [SerializeField] TurbineSettings settings;
    [Space]
    [SerializeField] bool isEnabled = true;

    ModifiedFloat load;

    #region Getters & Setters

    public bool IsEnabled => isEnabled;
    public float Speed { get; private set; } = 0;

    #endregion

    #region MonoBehaviour

    void Awake()
    {
        load = new ModifiedFloat(settings.BaseLoad);
    }

    void Update()
    {
        UpdateSpeed();
    }

    #endregion

    void UpdateSpeed()
    {
        float speed = isEnabled ? settings.Power / load : 0;

        Speed = Mathf.Lerp(Speed, speed, 1 / settings.Inertia);
    }

    public void AddLoad(Modifier modifier)
    {
        load.AddModifier(modifier);
    }

    public void RemoveLoad(Modifier modifier)
    {
        load.RemoveModifier(modifier);
    }

    public void Enable(bool active)
    {
        isEnabled = active;
    }
}
