using UnityEngine;

[CreateAssetMenu(fileName = "New Thruster Settings", menuName = "Podracer/Settings/Systems/Thruster")]
public class ThrusterSettings : ScriptableObject
{
    [SerializeField] float maxForce = 400;
    [SerializeField] CorrectorPIDSettings correctorSettings;

    public float MaxForce => maxForce;
    public CorrectorPIDSettings CorrectorSettings => correctorSettings;
}
