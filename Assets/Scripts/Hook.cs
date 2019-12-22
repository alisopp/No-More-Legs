using System;
using System.Diagnostics;
using Interfaces;
using UnityEngine;
using UnityEngine.Animations;
using Debug = UnityEngine.Debug;

namespace NoMoreLegs
{
    public class Hook : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        [SerializeField] private LineRenderer _lineRenderer;

        #endregion

        #region PRIVATE_VARIABLES

        private Rigidbody2D _rigidbody2D;
        private Vector3 _startPosition;
        private float _sqrtMaxRange;
        private IHookListener _hookListener;
        private int _wallLayer;
        private PositionConstraint _positionConstraint;
        private AudioSource _soundEffect;
        private Transform _shooterTransform;

        #endregion

        #region UNITY_LIFECYCLE

        private void Awake()
        {
            _shooterTransform = transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.isKinematic = true;
            _positionConstraint = GetComponent<PositionConstraint>();
            enabled = false;
            _wallLayer = LayerMask.NameToLayer("Wall");
            _soundEffect = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            if (enabled)
            {
                if ((_startPosition - transform.position).sqrMagnitude > _sqrtMaxRange)
                {
                    OnHookFailed();
                }
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, _shooterTransform.position);
            }
            
            
        }

        #endregion

        #region METHODS

        private void OnHookFailed()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.isKinematic = true;
            _hookListener.OnFailedReachedPosition();
            //transform.localPosition = Vector3.zero;
            _positionConstraint.constraintActive = true;
            enabled = false;
            _lineRenderer.enabled = false;
            var position = _shooterTransform.position;
            _lineRenderer.SetPosition(0, position);
            _lineRenderer.SetPosition(1, position);
            Debug.Log("Hook failed");
        }

        public void ResetHook()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.isKinematic = true;
            _positionConstraint.constraintActive = true;
            _lineRenderer.enabled = false;
            var position = _shooterTransform.position;
            _lineRenderer.SetPosition(0, position);
            _lineRenderer.SetPosition(1, position);
            Debug.Log("Reset Hook");
        }

        public void SetHookListener(IHookListener hookListener)
        {
            _shooterTransform = hookListener.GetTransform();
            ConstraintSource source = new ConstraintSource {sourceTransform = hookListener.GetTransform(), weight = 1f};
            _positionConstraint.AddSource(source);
            _hookListener = hookListener;
            _positionConstraint.constraintActive = true;
        }


        public void ShootHook(Vector3 velocity, float sqrtMaxRange)
        {
            _rigidbody2D.velocity = velocity;
            _rigidbody2D.isKinematic = false;
            _startPosition = transform.position;
            _sqrtMaxRange = sqrtMaxRange;
            _positionConstraint.constraintActive = false;
            float angle = (Mathf.Atan2(velocity.y, velocity.x) + (Mathf.PI / 2.0f)) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle - 90);
            _lineRenderer.enabled = true;
            enabled = true;
            _soundEffect.Play();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (enabled)
            {
                if (other.gameObject.layer == _wallLayer)
                {
                    _rigidbody2D.velocity = Vector2.zero;
                    _rigidbody2D.isKinematic = true;
                    enabled = false;
                    _hookListener.OnHookReachedPosition(other.ClosestPoint(transform.position));
                    Debug.Log("Hook reached");
                }
                else
                {
                    OnHookFailed();
                }
            }
        }

        #endregion
    }
}