using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : Enemy
{
    public int HpLimitUp;
    public int NeutralUp;
    public int NeutralDown;
    public int HpLimitDown;
    bool _moving;
    //public List<Protester> Targets = new List<Protester>();

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
        for (int i = 0; i < EnemyManager.GetComponent<EnemyManager>().Rioters.Count; i++)
        {
            Targets.Add(EnemyManager.GetComponent<EnemyManager>().Rioters[i]);
        }
        for (int i = 0; i < EnemyManager.GetComponent<EnemyManager>().Cops.Count; i++)
        {
            Targets.Add(EnemyManager.GetComponent<EnemyManager>().Cops[i]);
        }
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
                    //GetComponent<EnemyManager>().Workers.Remove(gameObject.GetComponent<Worker>());
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
                    //GetComponent<EnemyManager>().Workers.Add(gameObject.GetComponent<Worker>());
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
       
        for (int i = 0; i <= Targets.Count; i++)
        {
            if (!Targets[i].gameObject.activeSelf) continue;
            float tempDistance = Vector3.Distance(transform.position, Targets[i].transform.position);
            if (_target > tempDistance)
            {
                _target = tempDistance;
                Target = Targets[i].gameObject;
            }
        }
        _dir = (Target.transform.position - transform.position).normalized;
    }

    private void Neutral()
    {
        if (_moving) return;
        _dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        _moving = true;
        StartCoroutine(WaitForDirCD());
    }

    private void Bad()
    {
        _dir = Player.position - transform.position;
    }
    
    IEnumerator WaitForDirCD()
    {
        yield return new WaitForSeconds(3);
        _moving = false;
    }
}
