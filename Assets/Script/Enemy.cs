using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region vars
    public int CurrentHp;
    protected Rigidbody2D _rb;
<<<<<<< Updated upstream
    public GameObject EnemyManager;
    public Vector3 _dir;
    protected float _dist;
    public float MaxRange;
    public float MinRange;
    public float Speed = 150;
    public GameObject Target;
    public List<Enemy> Targets = new List<Enemy>();
    protected float _target;
    public Transform Player;
    public float ShootTimer;
    [Range(-1000f,0f)]public int EnemyDmg;
    #endregion
=======
    public float speed;

    public enum Bando
    {
        Good = 0,
        Neutral = 1,
        Bad = 2
    }

>>>>>>> Stashed changes

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
        EnemyManager = GameObject.Find("GameManager");
        CurrentHp = 0;
    }

    public virtual void ChangeHealth(int dmg) //Positvo es curar, negativo es recibir daño
    {
        CurrentHp += dmg;
    }
    public bool Spawn()
    {
        if (this.gameObject.activeSelf)
        {
            return false;
        }
        this.gameObject.SetActive(true);
        return true;
=======
        CurrentHp = MaxHp;
>>>>>>> Stashed changes
    }

    //public void TakeDmg(int dmg)
    //{
    //    CurrentHp -= dmg;
    //    Debug.Log("auch");
    //    if (CurrentHp <= 0)
    //    {
    //        //cambio de bando
    //    }
    //}
}
