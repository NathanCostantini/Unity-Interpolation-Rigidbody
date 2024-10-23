using UnityEngine;

[RequireComponent(typeof(Attractor), typeof(Stabilizer))]
public class PodController : RigidbodyComponent
{
    [SerializeField] EnginesManager engineManager;

    Attractor attractor;
    Stabilizer stabilizer;

    #region MonoBehaviour

    protected override void Awake()
    {
        base.Awake();

        attractor = GetComponent<Attractor>();
        stabilizer = GetComponent<Stabilizer>();
    }

    void FixedUpdate()
    {
        AttractTo();

        UpdateYRotation();
    }

    #endregion

    void AttractTo()
    {
        Vector3 targetPosition = engineManager.transform.position - engineManager.transform.forward * 7;

        attractor.AttractTo(targetPosition);
    }

    void UpdateYRotation()
    {
        Vector3 direction = (engineManager.transform.position - transform.position).normalized;
        float targetYAngle = Quaternion.LookRotation(direction).eulerAngles.y;

        stabilizer.RotateY(targetYAngle);
    }
}