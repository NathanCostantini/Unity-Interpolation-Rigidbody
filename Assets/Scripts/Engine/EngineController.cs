using UnityEngine;

[RequireComponent(typeof(Levitator), typeof(Attractor), typeof(Stabilizer))]
public class EngineController : MonoBehaviour
{
    Attractor attractor;
    Levitator levitator;
    Stabilizer stabilizer;

    Modifier heightModifier = new Modifier();

    Vector3 distanceFromCenter;

    #region MonoBehaviour

    void Awake()
    {
        attractor = GetComponent<Attractor>();
        levitator = GetComponent<Levitator>();
        stabilizer = GetComponent<Stabilizer>();
    }

    void Start()
    {
        levitator.AddHeightModifier(heightModifier);
    }

    #endregion

    public void AttractTo(Vector3 position, Quaternion rotation)
    {
        Vector3 targetPosition = position + rotation * distanceFromCenter;

        heightModifier.value = targetPosition.y - position.y;

        attractor.AttractTo(targetPosition);
    }

    public void RotateY(float targetAngle)
    {
        stabilizer.RotateY(targetAngle);
    }

    public void SetDistanceFromCenter(Vector3 position)
    {
        distanceFromCenter = Quaternion.Euler(-transform.eulerAngles) * (transform.position - position);
    }
}