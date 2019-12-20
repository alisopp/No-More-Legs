using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public start_movement startMovement;

    private int _groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        _groundLayer = LayerMask.GetMask("Ground");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _groundLayer)
        {
            startMovement.grounded = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _groundLayer)
            startMovement.grounded = false;
    }
}
