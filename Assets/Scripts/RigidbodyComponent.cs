using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class RigidbodyComponent : MonoBehaviour
{
    protected Rigidbody rb;

    #region Getters & Setters

    public float Speed => rb.velocity.magnitude * 3.6f;

    #endregion

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
}
