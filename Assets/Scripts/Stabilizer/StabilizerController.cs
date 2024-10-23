using UnityEngine;

[RequireComponent(typeof(Stabilizer), typeof(GroundDetector))]
public class StabilizerController : RigidbodyComponent
{
    [SerializeField] KeyCode manual = KeyCode.Space;
    [Space]
    [SerializeField] bool manualMode;

    Stabilizer stabilizer;
    GroundDetector groundDetector;

    #region MonoBehaviour

    protected override void Awake()
    {
        base.Awake();

        stabilizer = GetComponent<Stabilizer>();
        groundDetector = GetComponent<GroundDetector>();
    }

    void Update()
    {
        if (Input.GetKeyDown(manual) || Input.GetKeyUp(manual))
            manualMode = !manualMode;
    }

    void FixedUpdate()
    {
        Stabilize();
    }

    #endregion

    void Stabilize()
    {
        float targetAngle = 0;

        if (!manualMode)
            targetAngle = groundDetector.OnGround ? AngleFromGroundNormal(groundDetector.Hit.normal) : AngleFromVelocity(rb.velocity);

        stabilizer.RotateX(targetAngle);
    }

    float AngleFromGroundNormal(Vector3 normal)
    {
        Vector3 right = Vector3.Cross(Vector3.up, transform.forward);
        Vector3 projection = Vector3.ProjectOnPlane(normal, right);

        return Vector3.Angle(Vector3.up, projection) * Mathf.Sign(Vector3.Dot(normal, transform.forward));
    }

    float AngleFromVelocity(Vector3 velocity)
    {
        Vector3 direction = velocity.normalized;
        Vector3 projection = Vector3.ProjectOnPlane(direction, Vector3.up);

        float angle = direction.Equals(Vector3.down) ? 89 : Vector3.Angle(projection, direction) * Mathf.Sign(-Vector3.Dot(Vector3.up, direction));

        return angle * Mathf.Clamp01(Mathf.Log10(1 + velocity.magnitude / 10));
    }
}
