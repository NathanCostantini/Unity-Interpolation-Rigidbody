using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class Levitator : RigidbodyComponent
{
    [SerializeField] LevitatorSettings settings;

    Turbine turbine;
    GroundDetector groundDetector;

    CorrectorPIDFloat corrector;

    ModifiedFloat heightModifier;
    Modifier turbineLoad = new Modifier();

    #region Getters & Setters

    public CorrectorPIDSettings CorrectorSettings => settings.CorrectorSettings;

    #endregion

    #region MonoBehaviour

    protected override void Awake()
    {
        base.Awake();

        turbine = GetComponent<Turbine>();
        groundDetector = GetComponent<GroundDetector>();

        heightModifier = new ModifiedFloat(settings.TargetHeight);
        corrector = new CorrectorPIDFloat(CorrectorSettings);
    }

    void OnEnable()
    {
        turbine?.AddLoad(turbineLoad);
    }

    void OnDisable()
    {
        turbine?.RemoveLoad(turbineLoad);

        corrector.Reset();
    }

    void FixedUpdate()
    {
        Levitate();
    }

    #endregion

    void Levitate()
    {
        if (turbine != null && !turbine.IsEnabled || !groundDetector.OnGround)
        {
            corrector.Reset();
            return;
        }

        float magnitude = corrector.CalculateCorrection(groundDetector.Hit.distance, heightModifier);
        magnitude = Mathf.Clamp(magnitude, -settings.MaxForce, settings.MaxForce);

        turbineLoad.value = Mathf.Sqrt(Mathf.Abs(magnitude));

        rb.AddForce(Vector3.up * magnitude);
    }

    public void AddHeightModifier(Modifier modifier)
    {
        heightModifier.AddModifier(modifier);
    }

    public void RemoveHeightModifier(Modifier modifier)
    {
        heightModifier.RemoveModifier(modifier);
    }
}