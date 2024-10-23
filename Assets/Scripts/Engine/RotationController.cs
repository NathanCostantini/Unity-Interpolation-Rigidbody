using UnityEngine;

public class RotationController : RigidbodyComponent
{
    [SerializeField] float angularSpeed = 3;

    float inputCommand;

    void Update()
    {
        inputCommand = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rb.AddTorque(Vector3.up * angularSpeed * inputCommand);
    }
}
