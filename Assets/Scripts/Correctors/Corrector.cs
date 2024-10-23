using UnityEngine;

public abstract class Corrector<T>
{
    public abstract T CalculateCorrection(T currentValue, T targetValue);
    public abstract void Reset();
}
