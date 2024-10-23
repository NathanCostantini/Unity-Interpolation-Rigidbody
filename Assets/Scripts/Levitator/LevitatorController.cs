using UnityEngine;

[RequireComponent(typeof(Levitator))]
public class LevitatorController : MonoBehaviour
{
    [SerializeField] KeyCode hoverKey = KeyCode.Space;
    [Space]
    [SerializeField] bool hoverMode;

    Levitator levitator;

    Modifier heightModifier = new Modifier();

    #region MonoBehaviour

    void Awake()
    {
        levitator = GetComponent<Levitator>();
    }

    void Start()
    {
        levitator.AddHeightModifier(heightModifier);
    }

    void Update()
    {
        UpdateHoverMode();
    }

    #endregion

    void UpdateHoverMode()
    {
        if (Input.GetKeyDown(hoverKey) || Input.GetKeyUp(hoverKey))
            hoverMode = !hoverMode;

        heightModifier.value = hoverMode ? 2 : 0;
    }
}
