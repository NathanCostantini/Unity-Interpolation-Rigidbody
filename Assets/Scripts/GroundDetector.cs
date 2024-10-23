using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] float maxDistance = 20;

    RaycastHit hit;

    #region Getters & Setters

    public bool OnGround { get; private set; }
    public RaycastHit Hit => hit;

    #endregion

    void Update()
    {
        OnGround = Physics.Raycast(transform.position, Vector3.down, out hit, maxDistance);
    }
}
