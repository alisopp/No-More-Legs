using System;
using System.Diagnostics;
using Interfaces;
using UnityEngine;
using UnityEngine.Animations;

namespace NoMoreLegs
{
    public class Hook : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        #endregion

        #region PRIVATE_VARIABLES

        private Rigidbody2D _rigidbody2D;
        private Vector3 _startPosition;
        private float _sqrtMaxRange;
        private IHookListener _hookListener;
        private int _wallLayer;
        private PositionConstraint _positionConstraint;
        

        #endregion

        #region UNITY_LIFECYCLE

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.isKinematic = true;
            _positionConstraint = GetComponent<PositionConstraint>();
            enabled = false;
            _wallLayer = LayerMask.NameToLayer("Wall");
        }

        private void FixedUpdate()
        {
            if ((_startPosition - transform.position).sqrMagnitude > _sqrtMaxRange)
            {
                OnHookFailed();
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
        }

        public void ResetHook()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.isKinematic = true;
            _positionConstraint.constraintActive = true;
        }

        public void SetHookListener(IHookListener hookListener)
        {
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
            transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);
            enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == _wallLayer)
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.isKinematic = true;
                enabled = false;
                _hookListener.OnHookReachedPosition(other.ClosestPoint(transform.position));
            }
            else
            {
                OnHookFailed();
            }

        }

        #endregion
    }

}