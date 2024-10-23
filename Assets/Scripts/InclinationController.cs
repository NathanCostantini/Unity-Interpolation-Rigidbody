using UnityEngine;

[RequireComponent(typeof(Stabilizer))]
public class InclinationController : MonoBehaviour
{
    [SerializeField] float maxInclination = 35;

    float inputCommand;

    Stabilizer stabilizer;

    void Awake()
    {
        stabilizer = GetComponent<Stabilizer>();
    }

    void Update()
    {
        inputCommand = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        stabilizer.RotateZ(-inputCommand * maxInclination);
    }
}
