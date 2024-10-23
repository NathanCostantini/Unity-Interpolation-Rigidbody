using UnityEngine;

[CreateAssetMenu(fileName = "New Corrector Settings", menuName = "Podracer/Settings/Corrector")]
public class CorrectorPIDSettings : ScriptableObject
{
    [SerializeField] float k;
    [Space]
    [SerializeField] float kp;
    [SerializeField] float kd;
    [SerializeField] float ki;
    [Space]
    [SerializeField] float integralSaturation;

    #region Getters & Setters

    public float K => k;
    public float Kp => kp;
    public float Kd => kd;
    public float Ki => ki;
    public float IntegralSaturation => integralSaturation;

    #endregion

    public CorrectorPIDSettings(float k, float kp, float kd, float ki, float integralSaturation)
    {
        this.k = k;
        this.kp = kp;
        this.kd = kd;
        this.ki = ki;
        this.integralSaturation = integralSaturation;
    }
}
