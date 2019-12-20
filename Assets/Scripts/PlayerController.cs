using NoMoreLegs;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private ButtonDownListener[] _buttonDownListeners;
    private MovableObject _movableObject;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _movableObject = GetComponent<MovableObject>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        for (int i = 0; i < _buttonDownListeners.Length; i++)
        {
            _buttonDownListeners[i].Init(gameObject);
        }
    }

    private void Update()
    {
        for (int i = 0; i < _buttonDownListeners.Length; i++)
        {
            _buttonDownListeners[i].RunListener();
        }
    }

    public void OnMove(Vector3 velocity)
    {
        _rigidbody2D.velocity = velocity;
    }
}
