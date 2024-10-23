using UnityEngine;

[CreateAssetMenu(fileName = "New Turbine Settings", menuName = "Podracer/Settings/Systems/Turbine")]
public class TurbineSettings : ScriptableObject
{
    [SerializeField] float power = 100000;
    [SerializeField] float baseLoad = 300;
    [SerializeField] float inertia = 200;

    public float Power => power;
    public float BaseLoad => baseLoad;
    public float Inertia => inertia;
}
