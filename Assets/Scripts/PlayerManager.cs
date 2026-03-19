using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private float _moveHor = 0;
    private float _moveVert = 0;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moveHor = Input.GetAxis("Horizontal");
        _moveVert = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        _rb.AddForce(new Vector2(_moveHor, _moveVert) * _speed * Time.deltaTime, ForceMode2D.Impulse);   
    }
}
