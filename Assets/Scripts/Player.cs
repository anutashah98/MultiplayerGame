using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Player : NetworkBehaviour
{
    private bool _facingRight = true;
    //[SerializeField] private float _speed = 6f; 
    void Update()
    {
        if (hasAuthority)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            float speed = 6f * Time.deltaTime;
            transform.Translate(new Vector2(input.x * speed, input.y * speed));
            Animator anim = GetComponent<Animator>();
            if (input.x == 0 && input.y == 0)
            {
                anim.SetBool("Walk",false);
            }
            else
            {
                anim.SetBool("Walk", true);
            }

            if (!_facingRight && input.x > 0)
            {
                Flip();
            }
            else if(_facingRight && input.x < 0)
            {
                Flip();
            }
            
        }
    }

    private void Flip()
    {
        if (hasAuthority)
        {
            _facingRight = !_facingRight;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }
}
