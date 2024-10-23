using UnityEngine;

[RequireComponent(typeof(Turbine))]
public class Thruster : RigidbodyComponent
{
    [SerializeField] ThrusterSettings settings;

    float inputCommand;

    Turbine turbine;

    CorrectorPIDVector3 corrector;

    #region Getters & Setters

    public CorrectorPIDSettings CorrectorSettings => settings.CorrectorSettings;

    #endregion

    #region MonoBehaviour

    protected override void Awake()
    {
        base.Awake();

        turbine = GetComponent<Turbine>();

        corrector = new CorrectorPIDVector3(CorrectorSettings);
    }

    void OnDisable()
    {
        corrector.Reset();
    }

    void Update()
    {
        inputCommand = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Thrust(inputCommand);
    }

    #endregion

    void Thrust(float input)
    {
        if (!turbine.IsEnabled || input == 0) return;

        Vector3 targetVelocity = input > 0 ? transform.forward * turbine.Speed * input : Vector3.zero;

        Vector3 force = corrector.CalculateCorrection(rb.velocity, targetVelocity);

        float magnitude = Mathf.Clamp(force.magnitude, 0, settings.MaxForce);

        rb.AddForce(force.normalized * magnitude);
    }
}
