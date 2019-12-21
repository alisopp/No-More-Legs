using Interfaces;
using UnityEngine;

namespace NoMoreLegs
{
    public class StaticHookBehaviour : MovingBehaviour, IHookListener
    {
        #region EDITOR_VARIABLES

        [SerializeField] private Hook _hookPrefab;
        
        [SerializeField] private float _speed;
        [SerializeField] private float _collisionTreshold = 0.5f;
        [SerializeField] private float _maximumDistance = 10;

        #endregion

        #region PRIVATE_VARIABLES

        private Camera _camera;
        private Hook _hook;
        private PlayerController _playerController;
        private Vector3 _direction;
        private Rigidbody2D _target;
        private Transform _targetTransform;
        private bool _reachedPosition;
        private Vector3 _targetPosition;
        private int _layerMask;
        private float _gravityScale = 1;
        private Collider2D _collider2D;

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
            _hook = Instantiate(_hookPrefab.gameObject).GetComponent<Hook>();
            _hook.SetHookListener(this);
        }

        public override void OnButtonDown()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var position = _targetTransform.position;
            var playerPosition = position;
            _direction = (mousePosition - playerPosition).normalized;
            
            
            
            _hook.ShootHook(_direction * _speed, _maximumDistance);
        }

        public override void OnButtonUp()
        {
            _target.velocity = Vector2.zero;
            _target.gravityScale = _gravityScale;
            _target.isKinematic = false;
            _reachedPosition = false;
            _hook.ResetHook();
        }

        public override void RunBehaviour()
        {
            if (!_reachedPosition)
            {
                if ((_targetTransform.position - _hook.transform.position).sqrMagnitude < _collisionTreshold)
                {
                    _reachedPosition = true;
                    _target.velocity = Vector2.zero;
                }
            }
        }
        
        public void OnHookReachedPosition(Vector3 targetPosition)
        {
            var direction = (targetPosition - _targetTransform.position).normalized;
            _target.velocity = direction * _speed;
            _target.gravityScale = 0;
            _reachedPosition = false;
            _target.isKinematic = true;
        }

        public void OnFailedReachedPosition()
        {
            
        }

        public Transform GetTransform()
        {
            return transform;
        }

        #endregion


    }
}