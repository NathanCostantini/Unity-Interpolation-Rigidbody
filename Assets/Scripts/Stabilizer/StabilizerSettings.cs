using UnityEngine;

[CreateAssetMenu(fileName = "New Stabilizer Settings", menuName = "Podracer/Settings/Systems/Stabilizer")]
public class StabilizerSettings : ScriptableObject
{
    [SerializeField] Vector3 smoothTime = new Vector3(1, 0.5f, 0.5f);

    public Vector3 SmoothTime => smoothTime;
}
