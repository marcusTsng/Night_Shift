using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private Vector2 _mouse_pos;
    private float _moveHor = 0;
    private float _moveVert = 0;
    private Rigidbody2D _rb;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject _flashlight;
    public bool flashlight_on = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moveHor = Input.GetAxis("Horizontal");
        _moveVert = Input.GetAxis("Vertical");
        _mouse_pos = Input.mousePosition;

        if (Input.GetMouseButtonUp(0)) //toggle flashlight
        {
            flashlight_on = !flashlight_on;
            _flashlight.SetActive(flashlight_on);
        }
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveHor, _moveVert) * _speed * Time.deltaTime;   

        // Flashlight handling
        Vector3 worldPos = cam.ScreenToWorldPoint(_mouse_pos);
        Vector3 dir = worldPos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
