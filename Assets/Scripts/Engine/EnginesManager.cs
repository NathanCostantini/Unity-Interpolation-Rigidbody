using UnityEngine;

public class EnginesManager : MonoBehaviour
{
    [SerializeField] EngineController[] engines;

    #region MonoBehaviour

    void Awake()
    {
        UpdateTransform();

        InitializeEngines();
    }

    void Update()
    {
        UpdateTransform();

        StabilizeYRotation();
    }

    void FixedUpdate()
    {
        AttractEngines();
    }

    #endregion

    void InitializeEngines()
    {
        foreach (var engine in engines)
            engine.SetDistanceFromCenter(transform.position);
    }

    void UpdateTransform()
    {
        transform.position = CalculatePosition();
        transform.rotation = CalculateRotation();
    }

    void AttractEngines()
    {
        foreach (var engine in engines)
            engine.AttractTo(transform.position, transform.rotation);
    }

    void StabilizeYRotation()
    {
        foreach (var engine in engines)
            engine.RotateY(transform.rotation.eulerAngles.y);
    }

    #region Calculate

    Vector3 CalculatePosition()
    {
        Vector3 center = Vector3.zero;
        foreach (var engine in engines)
            center += engine.transform.position;
        return center / engines.Length;
    }

    Quaternion CalculateRotation()
    {
        Vector3 eulerAngles = Vector3.zero;
        foreach (var engine in engines)
        {
            Vector3 euler = Vector3.zero;
            euler.x = Utils.Angle360To180(engine.transform.eulerAngles.x);
            euler.y = Utils.Angle360To180(engine.transform.eulerAngles.y);
            euler.z = Utils.Angle360To180(engine.transform.eulerAngles.z);
            eulerAngles += euler;
        }
        return Quaternion.Euler(eulerAngles / engines.Length);
    }

    #endregion
}