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
        [SerializeField]  private float _gravityScale = 0.5f;
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
            _reachedPosition = true;
            _hook.SetHookListener(this);
        }

        public override void OnButtonDown()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var position = _targetTransform.position;
            var playerPosition = position;
            _direction = (mousePosition - playerPosition).normalized;
            _target.constraints = RigidbodyConstraints2D.None;
            
            
            _hook.ShootHook(_direction * _speed, _maximumDistance);
        }

        public override void OnButtonUp()
        {
            //_target.velocity = Vector2.zero;
            var velocity = _target.velocity;
            Debug.Log("Is Not Kinematic");
            //_target.isKinematic = false;
            _target.velocity = velocity;
            _target.gravityScale = _gravityScale;
            _target.constraints = RigidbodyConstraints2D.None;
            _reachedPosition = true;
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
                    _target.constraints = RigidbodyConstraints2D.FreezePosition;
                }else
                {
                    var direction = (_targetPosition - _targetTransform.position).normalized;
                    _target.velocity = direction * _speed;
                }
            }
            
        }
        
        public void OnHookReachedPosition(Vector3 targetPosition)
        {
            var direction = (targetPosition - _targetTransform.position).normalized;
            _targetPosition = targetPosition;
            _target.velocity = direction * _speed;
            _target.gravityScale = 0;
            _reachedPosition = false;
            Debug.Log("Is Kinematic");
            //_target.isKinematic = true;
        }

        public override void ResetBehaviour()
        {
            _hook.ResetHook();
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