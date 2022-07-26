using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    private int _rspeed;
    public int sprintSpeed;
    private Transform _mytransform;

    void Start()
    {
        _mytransform = GetComponent<Transform>();
        speed = 5;
        _rspeed = speed;
    }

    void Update()
    {
        //_mytransform.Translate(speed * Time.deltaTime * Vector2.right);
        //if (Input.GetKey(KeyCode.LeftShift))
        //{

        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    _mytransform.Translate(speed * Time.deltaTime * Vector2.right);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    _mytransform.Translate(speed * Time.deltaTime * Vector2.left);
        //}
        //_mytransform.Translate(speed * Time.deltaTime * Input.GetAxis("Horizontal") * Vector2.right);
        //_mytransform.Translate(speed * Time.deltaTime * Input.GetAxis("Vertical") * Vector2.up);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _rspeed = sprintSpeed;
        }
        else
        {
            _rspeed = speed;
        }

        _mytransform.Translate(_rspeed * Time.deltaTime * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
}
