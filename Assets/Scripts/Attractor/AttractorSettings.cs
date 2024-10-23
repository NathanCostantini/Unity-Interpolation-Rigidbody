using UnityEngine;

[CreateAssetMenu(fileName = "New Attractor Settings", menuName = "Podracer/Settings/Systems/Attractor")]
public class AttractorSettings : ScriptableObject
{
    [SerializeField] float maxForce = 300;
    [SerializeField] CorrectorPIDSettings correctorSettings;

    public float MaxForce => maxForce;
    public CorrectorPIDSettings CorrectorSettings => correctorSettings;
}
