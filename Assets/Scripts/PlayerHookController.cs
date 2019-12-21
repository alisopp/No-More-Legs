using UnityEngine;

namespace NoMoreLegs
{
    public class PlayerHookController : MonoBehaviour
    {
        [SerializeField]
        private ButtonDownListener[] _buttonDownListeners;
        private MovableObject _movableObject;

        private void Awake()
        {
            _movableObject = GetComponent<MovableObject>();
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
    }

}