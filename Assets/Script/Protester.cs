using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protester : Enemy
{


    void Update()
    {
        _dist = Vector3.Distance(Player.transform.position, transform.position);
        _dir = (Player.transform.position - transform.position);
        if (_dist < MinRange)
        {
            _dir *= -1;
        }
        else if (_dist > MaxRange)
        {
            _dir *= -1;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = Time.deltaTime * Speed * _dir; 
    }

    private void Running()
    {

    }
    
    private void Standing()
    {

    }

    private void Following()
    {

    }
}
