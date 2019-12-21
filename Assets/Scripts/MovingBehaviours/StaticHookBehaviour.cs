using UnityEngine;

namespace NoMoreLegs
{
    public class StaticHookBehaviour : MovingBehaviour
    {
        #region EDITOR_VARIABLES

        [SerializeField] private Hook _hook;
        [SerializeField] private float _speed;
        [SerializeField] private float _collisionTreshold = 0.5f;

        #endregion

        #region PRIVATE_VARIABLES

        private Camera _camera;
        private PlayerController _playerController;
        private Vector3 _direction;
        private Rigidbody2D _target;
        private Transform _targetTransform;
        private bool _reachedPosition;
        private Vector3 _targetPosition;
        private int _layerMask;
        private float _gravityScale = 1;

        #endregion

        #region UNITY_LIFECYCLE

        #endregion

        #region METHODS

        public override void Init(GameObject gameObject)
        {
            _camera = Camera.main;
            _playerController = gameObject.GetComponent<PlayerController>();
            _target = gameObject.GetComponent<Rigidbody2D>();
            _targetTransform = _playerController.transform;
            _layerMask = LayerMask.GetMask("Wall", "Enemy");
        }

        public override void OnButtonDown()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var position = _targetTransform.position;
            var playerPosition = position;
            _direction = (mousePosition - playerPosition).normalized;
            _reachedPosition = false;
            RaycastHit2D info = Physics2D.Raycast(position, _direction, Mathf.Infinity, _layerMask);
            
            if (info.collider != null)
            {
                _target.velocity = _direction * _speed;
                _targetPosition = info.point;
                _target.gravityScale = 0;
            }
        }

        public override void OnButtonUp()
        {
            //_target.velocity = Vector2.zero;
            _target.gravityScale = _gravityScale;
        }

        public override void RunBehaviour()
        {
            if (!_reachedPosition)
            {
                if ((_targetTransform.position - _targetPosition).sqrMagnitude < _collisionTreshold)
                {
                    _reachedPosition = true;
                    _target.velocity = Vector2.zero;
                }
            }
        }

        #endregion
    }
}