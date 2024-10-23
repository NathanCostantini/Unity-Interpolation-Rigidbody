using UnityEngine;

[System.Serializable]
public class CorrectorPIDFloat : CorrectorPID<float>
{
    bool derivativeInitialized;

    float integral;
    float previousError;

    public CorrectorPIDFloat() : base() { }

    public CorrectorPIDFloat(CorrectorPIDSettings settings) : base(settings)
    {

    }

    public override float CalculateCorrection(float currentValue, float targetValue)
    {
        float error = targetValue - currentValue;

        float proportional = CalculateProportional(error);
        float derivative = CalculateDerivative(error);
        float integral = CalculateIntegral(error);

        return settings.K * (proportional + derivative + integral);
    }

    float CalculateProportional(float error)
    {
        return settings.Kp * error;
    }

    float CalculateDerivative(float error)
    {
        float derivative = 0;

        if (derivativeInitialized)
            derivative = (error - previousError) / Time.fixedDeltaTime;
        else
            derivativeInitialized = true;

        previousError = error;

        return settings.Kd * derivative;
    }

    float CalculateIntegral(float error)
    {
        integral += error * Time.fixedDeltaTime;

        integral = IntegralClamp(integral);

        return settings.Ki * integral;
    }

    public override void Reset()
    {
        integral = 0;
        derivativeInitialized = false;
    }
}
