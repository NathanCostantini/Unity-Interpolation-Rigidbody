using UnityEngine;

public abstract class CorrectorPID<T> : Corrector<T>
{
    [SerializeField] protected CorrectorPIDSettings settings;

    public CorrectorPIDSettings Settings => settings;

    #region Constructors

    public CorrectorPID()
    {

    }

    public CorrectorPID(CorrectorPIDSettings settings)
    {
        this.settings = settings;
    }

    #endregion

    protected float IntegralClamp(float value)
    {
        return Mathf.Clamp(value, -settings.IntegralSaturation, settings.IntegralSaturation);
    }
}
