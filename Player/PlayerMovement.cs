using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _moveX;

    private Rigidbody2D _rigid;
    [SerializeField] private AudioSource _walk;
    private float _moveY;
    public float _speed;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (DetectUI.instance._UIFlag)
        {
            _rigid.velocity = Vector3.zero;
            _walk.Stop();
        }
        else
            Move();
    }
    private void FixedUpdate()
    {
        _rigid.velocity = new Vector3(_moveX, _moveY, 0).normalized * _speed;
        if ((Mathf.Abs(_rigid.velocity.x) > 0.1 || Mathf.Abs(_rigid.velocity.y) > 0.1)&&!_walk.isPlaying)
        {
            _walk.Play();
        }
        else if(Mathf.Abs(_rigid.velocity.x) <= 0.1&& Mathf.Abs(_rigid.velocity.y) <= 0.1&&_walk.isPlaying) 
        {
            _walk.Stop();
        }
    }
    private void Move()
    {
        _moveX = Input.GetAxisRaw("Horizontal");
        _moveY = Input.GetAxisRaw("Vertical");
    }
}
