using UnityEngine;

namespace NoMoreLegs
{
    [System.Serializable]
    public class ButtonDownListener
    {
        [SerializeField] private MovingBehaviour _movingBehaviour;
        [SerializeField] private string _button;

        public void Init(GameObject gameObject)
        {
            _movingBehaviour.Init(gameObject);
        }

        public void Reset()
        {
            _movingBehaviour.ResetBehaviour();
        }

        public void RunListener()
        {
            if (Input.GetButtonDown(_button))
            {
                _movingBehaviour.OnButtonDown();
            }
            else if (Input.GetButtonUp(_button))
            {
                _movingBehaviour.OnButtonUp();
            }
            _movingBehaviour.RunBehaviour();
        }
    }
}