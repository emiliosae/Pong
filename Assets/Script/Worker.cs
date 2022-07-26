using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : Enemy
{
    public int HpLimitUp;
    public int NeutralUp;
    public int NeutralDown;
    public int HpLimitDown;

    public enum BANDO
    {
        Good = 0,
        Neutral = 1,
        Bad = 2
    }

    public BANDO Bando;

    //protected override void Start()
    //{
    //    CurrentHp = 0;
    //}

    private void Update()
    {
        switch (Bando)
        {
            case BANDO.Good:
                Good();
                break;
            case BANDO.Neutral:
                Neutral();
                break;
            case BANDO.Bad:
                Bad();
                break;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = Speed * Time.fixedDeltaTime * _dir;
    }

    public override void ChangeHealth(int dmg)
    {
        base.ChangeHealth(dmg);
        switch (Bando)
        {
            case BANDO.Neutral:
                if (CurrentHp < NeutralDown)
                {
                    Bando = BANDO.Bad;
                    this.gameObject.transform.tag = "Enemy";
                }
                else if (CurrentHp > NeutralUp)
                {
                    Bando = BANDO.Good;
                    this.gameObject.transform.tag = "Good";
                    GetComponent<EnemyManager>().GoodWorkers.Add(gameObject.GetComponent<Worker>());
                    GetComponent<EnemyManager>().Workers.Remove(gameObject.GetComponent<Worker>());
                }
                break;
            case BANDO.Good:
                if (CurrentHp > HpLimitUp)
                {
                    CurrentHp = HpLimitUp;
                }
                else if (CurrentHp < NeutralUp)
                {
                    Bando = BANDO.Neutral;
                    this.gameObject.transform.tag = "Neutral";
                    GetComponent<EnemyManager>().Workers.Add(gameObject.GetComponent<Worker>());
                    GetComponent<EnemyManager>().GoodWorkers.Remove(gameObject.GetComponent<Worker>());
                }
                break;
            case BANDO.Bad:
                if (CurrentHp < HpLimitDown)
                {
                    CurrentHp = HpLimitDown;
                }
                else if (CurrentHp > NeutralDown)
                {
                    Bando = BANDO.Neutral;
                    this.gameObject.transform.tag = "Neutral";
                }
                break;
        }
    }

    private void Good()
    {
        for (int value = 0; value <= Targets.Length; value++)
        {
            float tempDistance = Vector3.Distance(transform.position, Targets[value].transform.position);
            if (_target > tempDistance)
            {
                _target = tempDistance;
                Target = Targets[value];
            }
        }
        _dir = (Target.transform.position - transform.position).normalized;
    }

    private void Neutral()
    {
        _dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
    }

    private void Bad()
    {
        _dir = Player.position - transform.position;
    }
}
