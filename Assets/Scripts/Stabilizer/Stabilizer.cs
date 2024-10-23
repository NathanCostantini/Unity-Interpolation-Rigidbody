using UnityEngine;

public class Stabilizer : MonoBehaviour
{
    [SerializeField] StabilizerSettings settings;

    bool previousState;

    Vector3 angularVelocities;

    public void RotateX(float targetAngle)
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.x = Mathf.SmoothDampAngle(transform.eulerAngles.x, targetAngle, ref angularVelocities.x, settings.SmoothTime.x);
        transform.eulerAngles = newRotation;
    }
    public void RotateY(float targetAngle)
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref angularVelocities.y, settings.SmoothTime.y);
        transform.eulerAngles = newRotation;
    }
    public void RotateZ(float targetAngle)
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref angularVelocities.z, settings.SmoothTime.z);
        transform.eulerAngles = newRotation;
    }
}