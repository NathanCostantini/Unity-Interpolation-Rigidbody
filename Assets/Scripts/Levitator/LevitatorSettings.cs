using UnityEngine;

[CreateAssetMenu(fileName = "New Levitator Settings", menuName = "Podracer/Settings/Systems/Levitator")]
public class LevitatorSettings : ScriptableObject
{
    [SerializeField] float maxForce = 300;
    [SerializeField] float targetHeight = 4;
    [SerializeField] CorrectorPIDSettings correctorSettings;

    public float MaxForce => maxForce;
    public float TargetHeight => targetHeight;
    public CorrectorPIDSettings CorrectorSettings => correctorSettings;
}
