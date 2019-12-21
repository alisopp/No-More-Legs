using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_movement : MonoBehaviour
{
    private static readonly int ANIM_MOVEMENT = Animator.StringToHash("IsMoving");
    private static readonly int ANIM_JUMPING = Animator.StringToHash("IsJumping");
    
    public float runSpeed;
    public float jumpForce;
    private Rigidbody2D _rb;
    private SpriteRenderer spriteRend;
    private PlayerController _playerController;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        _playerController = GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(horizontal * runSpeed, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _rb.AddForce(Vector2.up * jumpForce);
        }
        
        if (Mathf.Abs(_rb.velocity.x) > 0.05f && grounded)
        {
            _playerController.SetAnimationParameter(ANIM_MOVEMENT, true);
        }
        else
        {
            _playerController.SetAnimationParameter(ANIM_MOVEMENT, false);
        }

        if (!grounded)
        {
            _playerController.SetAnimationParameter(ANIM_JUMPING, true);
        }
        else
        {
            _playerController.SetAnimationParameter(ANIM_JUMPING, false);
        }
    }

    private void OnDisable()
    {
        _playerController.SetAnimationParameter(ANIM_JUMPING, false);
        _playerController.SetAnimationParameter(ANIM_MOVEMENT, false);
    }
}
