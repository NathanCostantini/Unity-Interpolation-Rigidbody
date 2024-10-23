using UnityEngine;

public class Attractor : RigidbodyComponent
{
    [SerializeField] AttractorSettings settings;
    [Space]
    [SerializeField] bool isEnabled = true;

    CorrectorPIDVector3 corrector;

    #region Getters & Setters

    public CorrectorPIDSettings CorrectorSettings => settings.CorrectorSettings;

    #endregion

    #region MonoBehaviour

    protected override void Awake()
    {
        base.Awake();

        corrector = new CorrectorPIDVector3(CorrectorSettings);
    }

    void OnDisable()
    {
        corrector.Reset();
    }

    #endregion

    public void AttractTo(Vector3 targetPosition)
    {
        Vector3 force = corrector.CalculateCorrection(transform.position, targetPosition);

        float magnitude = Mathf.Clamp(rb.mass * force.magnitude, 0, settings.MaxForce);

        rb.AddForce(force.normalized * magnitude);
    }

    public void Enable(bool active)
    {
        isEnabled = active;
    }
}