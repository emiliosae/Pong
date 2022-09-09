using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region vars
    public int CurrentHp;
    protected Rigidbody2D _rb;
    public GameObject EnemyManager;
    [SerializeField]
    protected Vector3 _dir;
    protected float _dist;
    public float MaxRange;
    public float MinRange;
    public float Speed = 150;
    public GameObject Target;
    public GameObject[] Targets;
    protected float _target;
    public Transform Player;
    public float ShootTimer;
    [Range(-1000f,0f)]public int EnemyDmg;
    #endregion

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Targets = GameObject.FindGameObjectsWithTag("Enemy");
        CurrentHp = 0;
    }

    public virtual void ChangeHealth(int dmg) //Positvo es curar, negativo es recibir daño
    {
        CurrentHp += dmg;
    }
    public void Spawn(bool flag)
    {
        if (this.gameObject.activeSelf)
        {
            flag = false;
            return;
        }
        this.gameObject.SetActive(true);
        flag = true;
        return;
    }
}
