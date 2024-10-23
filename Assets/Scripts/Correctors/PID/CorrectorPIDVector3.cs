using UnityEngine;

[System.Serializable]
public class CorrectorPIDVector3 : CorrectorPID<Vector3>
{
    bool derivativeInitialized;

    Vector3 integral;
    Vector3 previousError;

    public CorrectorPIDVector3() : base() { }

    public CorrectorPIDVector3(CorrectorPIDSettings settings) : base(settings)
    {

    }

    public override Vector3 CalculateCorrection(Vector3 currentValue, Vector3 targetValue)
    {
        Vector3 error = targetValue - currentValue;

        Vector3 proportional = CalculateProportional(error);
        Vector3 derivative = CalculateDerivative(error);
        Vector3 integral = CalculateIntegral(error);

        return settings.K * (proportional + derivative + integral);
    }

    Vector3 CalculateProportional(Vector3 error)
    {
        return settings.Kp * error;
    }

    Vector3 CalculateDerivative(Vector3 error)
    {
        Vector3 derivative = Vector3.zero;

        if (derivativeInitialized)
            derivative = (error - previousError) / Time.fixedDeltaTime;
        else
            derivativeInitialized = true;

        previousError = error;

        return settings.Kd * derivative;
    }

    Vector3 CalculateIntegral(Vector3 error)
    {
        integral += error * Time.fixedDeltaTime;

        integral.x = IntegralClamp(integral.x);
        integral.y = IntegralClamp(integral.y);
        integral.z = IntegralClamp(integral.z);

        return settings.Ki * integral;
    }

    public override void Reset()
    {
        integral = Vector3.zero;
        derivativeInitialized = false;
    }
}
