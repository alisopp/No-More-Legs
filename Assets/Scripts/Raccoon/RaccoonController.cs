using System;
using UnityEngine;
using UnityEngine.Animations;

namespace NoMoreLegs.Raccoon
{
    public class RaccoonController : MonoBehaviour
    {
        
        
        private static readonly int ANIM_MOVEMENT = Animator.StringToHash("IsMoving");
        private static readonly int ANIM_MOVEMENT_STEALING = Animator.StringToHash("IsMovingStealing");
        #region EDITOR_VARIABLES

        [SerializeField] private Animator _animator;
        [SerializeField] private float _stealSpeed;
        [SerializeField] private GameObject _stolenLegsConstraintPrefab;
        [SerializeField] private GameObject _stolenItemSpot;
        #endregion

        #region PRIVATE_VARIABLES

        private Rigidbody2D _rigidbody2D;
        private bool _isFlipped;
        private PositionConstraint _stolenLegs;

        #endregion

        #region UNITY_LIFECYCLE

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Mathf.Abs(_rigidbody2D.velocity.x) > 0)
            {
                _animator.SetBool(ANIM_MOVEMENT, true);
            }
            else
            {
                _animator.SetBool(ANIM_MOVEMENT, false);
            }

            if (_isFlipped && _rigidbody2D.velocity.x < -0.02f)
            {
                var trans = transform;
                var scale = trans.localScale;
                scale.x *= -1;
                trans.localScale = scale;
                _isFlipped = false;
            }else if (!_isFlipped && _rigidbody2D.velocity.x > 0.02f)
            {
                var trans = transform;
                var scale = trans.localScale;
                scale.x *= -1;
                trans.localScale = scale;
                _isFlipped = true;
            }
        }

        #endregion

        #region METHODS

        public void StartStealing()
        {
            _rigidbody2D.velocity = new Vector2(-_stealSpeed, 0f);
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals("Player"))
            {
                _rigidbody2D.velocity = new Vector2(_stealSpeed * 2, 0f);
                GameManager.GetInstance().CurrentPlayer.LoseLegs();
                _stolenLegs = Instantiate(_stolenLegsConstraintPrefab).GetComponent<PositionConstraint>();
                ConstraintSource source = new ConstraintSource();
                source.weight = 1f;
                source.sourceTransform = _stolenItemSpot.transform;
                _stolenLegs.AddSource(source);
                _stolenLegs.constraintActive = true;
                _animator.SetBool(ANIM_MOVEMENT_STEALING, true);
            }else if (other.tag.Equals("RacoonCave"))
            {
                gameObject.SetActive(false);
                GameManager.GetInstance().CurrentPlayer.GotHook();
            }

        }

        #endregion
    }

}