using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject Father; 
    public enum Axis { x, y }
    public Axis axis = Axis.y;
    bool inverted;


    private void Update()
    {
        switch (axis)
        {
            case Axis.x:
                transform.right = Father.GetComponent<Protester>()._dir; // Point x axis towards direction
                break;

            case Axis.y:
                transform.up = Father.GetComponent<Protester>()._dir; // Point y axis towards direction
                break;

            default:
                break;
        }
    }
}
