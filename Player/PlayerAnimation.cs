using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _rigid;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        _anim.SetFloat("moveX", _rigid.velocity.x);
        _anim.SetFloat("moveY", _rigid.velocity.y);
        if ((Input.GetAxisRaw("Horizontal")!=0|| Input.GetAxisRaw("Vertical")!=0)&&!DetectUI.instance._UIFlag)
        {
            _anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            _anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
}
