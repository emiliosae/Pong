using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHp = 10;
    public int CurrentHp;
    protected Rigidbody2D _rb;
    public float speed;
    //public List<GameObject> Targets = new List<GameObject>();
    public GameObject Target;
    public GameObject[] Targets;
    private float _target;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Targets = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void TakeDmg(int dmg)
    {
        CurrentHp -= dmg;

        if (CurrentHp <= 0)
        {
            //cambio de bando
        }
    }
    protected void Good()
    {
        for (int value = 0; value <= Targets.Length; value ++)
        {
            float tempDistance = Vector3.Distance(transform.position, Targets[value].transform.position);
            if( _target < tempDistance)
            {
                _target = tempDistance;
                Target = Targets[value];
            }
        }
        //poner movimiento
    } 
}
