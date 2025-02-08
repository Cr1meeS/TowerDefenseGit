using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private InputActions _inputActions;

    public delegate void Action();
    public event Action EventStartClick;
    public event Action EventEndClick;
    public event Action EventPerformedClick;

    private static InputHandler _instance;

    public static InputHandler Instance
    {
        get
        {
            if (_instance == null) _instance = new InputHandler();
            return _instance;
        }
    }

    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void Start()
    {
        _inputActions.Game.MouseLeftClick.started += ctx => ClickStatrt();
        _inputActions.Game.MouseLeftClick.canceled += ctx => ClickEnd();
        _inputActions.Game.MouseLeftClick.performed += ctx => ClickPerformed();
    }

    private void ClickStatrt()
    {
        EventStartClick?.Invoke();
    }

    private void ClickEnd()
    {
        EventEndClick?.Invoke();
    }

    private void ClickPerformed()
    {
        EventPerformedClick?.Invoke();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
}
