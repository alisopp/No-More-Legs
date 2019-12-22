using System;
using NoMoreLegs;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    
    
    [SerializeField]
    private Animator _animator;

    [SerializeField] private GameObject[] _objectsToDisable;
    
    private MovableObject _movableObject;
    private PlayerHookController _playerHookController;
    private start_movement _startMovement;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _capsuleCollider2D;
    
    private void Awake()
    {
        _playerHookController = GetComponent<PlayerHookController>();
        _startMovement = GetComponent<start_movement>();
        _playerHookController.enabled = false;
        _startMovement.enabled = true;
        _rb = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    public void SetAnimationParameter(int hashedAnim, bool value)
    {
        _animator.SetBool(hashedAnim, value);
    }

    public void StopController()
    {
        var velocity = _rb.velocity;
        velocity.x = 0;
        _rb.velocity = velocity;
        _playerHookController.enabled = false;
        _startMovement.enabled = false;
    }

    public void LoseLegs()
    {
        _rb.freezeRotation = false;
        foreach (var leg in _objectsToDisable)
        {
            leg.SetActive(false);
        }
        _capsuleCollider2D.offset = new Vector2(0.03f, 1.1f);
        _capsuleCollider2D.size = new Vector2(2.57f, 4.47f);
    }

    public void GotHook()
    {
        _playerHookController.enabled = true;
    }
}
