using UnityEngine;

namespace NoMoreLegs
{
    public class StaticHookBehaviour : MovingBehaviour
    {
        #region EDITOR_VARIABLES

        [SerializeField] private Hook _hook;
        [SerializeField] private float _speed;
        #endregion

        #region PRIVATE_VARIABLES

        private Camera _camera;
        private PlayerController _playerController;
        private Vector3 _direction;

        #endregion

        #region UNITY_LIFECYCLE

        #endregion

        #region METHODS

        public override void Init(GameObject gameObject)
        {
            _camera = Camera.main;
            _playerController = gameObject.GetComponent<PlayerController>();
        }

        public override void OnButtonDown()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var playerPosition = _playerController.transform.position;
            _direction = (mousePosition - playerPosition).normalized;
            _playerController.OnMove(_direction * _speed);
            
        }

        public override void OnButtonUp()
        {
            _playerController.OnMove(Vector3.zero);
        }

        public override void RunBehaviour()
        {
            
        }

        #endregion
    }

}