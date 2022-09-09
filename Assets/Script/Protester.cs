using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protester : Enemy
{
    public Transform Chamber;
    public GameObject BulletPref;
    List<GameObject> _bulletList = new List<GameObject>();
    public int Dmg;
    [SerializeField] private float _shootTimer;
    public int MaxHP;
    //public List<Worker> Targets = new List<Worker>();

    public enum STATE
    {
        Running =0,
        Standing =1,
        Following =2
    }

    public STATE State = STATE.Standing;

    private void OnEnable()
    {
        _shootTimer = Time.time + Random.Range(1, 3) + Random.Range(0f, 0.99f);
    }

    void Update()
    {
        if (CurrentHp >= MaxHP)
        {
            gameObject.SetActive(false);
            EnemyManager.GetComponent<EnemyManager>().Rioters.Remove(gameObject.GetComponent<Protester>());
            EnemyManager.GetComponent<EnemyManager>().Cops.Remove(gameObject.GetComponent<Protester>());
        }
        _dist = Vector3.Distance(Player.transform.position, transform.position);
        for (int i = 0; i < EnemyManager.GetComponent<EnemyManager>().Workers.Count; i++)
        {
            Targets.Add(EnemyManager.GetComponent<EnemyManager>().Workers[i]);
        }
        for (int i =0; i< EnemyManager.GetComponent<EnemyManager>().GoodWorkers.Count; i++)
        {
            Targets.Add(EnemyManager.GetComponent<EnemyManager>().GoodWorkers[i]);
        }
        switch (State)
        {
            case STATE.Following:
                Following();
                if (_dist < MaxRange)
                {
                    State = STATE.Standing;
                }
                break;
            case STATE.Standing:
                Standing();
                if (_dist < MinRange)
                {
                    State = STATE.Running;
                }
                else if (_dist > MaxRange)
                {
                    State = STATE.Following;
                }
                break;
            case STATE.Running:
                Running();
                if(_dist> MinRange)
                {
                    State = STATE.Standing;
                }
                break;
        }
        if (Time.time >= _shootTimer)
        {
            foreach (GameObject bullet in _bulletList)
            {
                if (bullet.GetComponent<Bullet>().Fire(Chamber)) return;
            }
            GameObject tempBullet = Instantiate(BulletPref);
            _bulletList.Add(tempBullet);
            tempBullet.GetComponent<Bullet>().Dmg = Dmg;
            tempBullet.GetComponent<Bullet>().Fire(Chamber);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = Time.deltaTime * Speed * _dir; 
    }

    private void OnDisable()
    {
        EnemyManager.GetComponent<EnemyManager>().Rioters.Remove(this.gameObject.GetComponent<Protester>());
        EnemyManager.GetComponent<EnemyManager>().Cops.Remove(this.gameObject.GetComponent<Protester>());
    }

    private void Running()
    {
        _dir = -(Player.transform.position - transform.position);
    }
    
    private void Standing()
    {
        _dir = new Vector3(0, 0, 0);
    }

    private void Following()
    {
        _dir = Player.transform.position - transform.position;
    }

    private void Shoot()
    {
        foreach (GameObject bullet in _bulletList)
        {
            if (bullet.GetComponent<Bullet>().Fire(Chamber)) return;
        }
        GameObject tempBullet = Instantiate(BulletPref);
        _bulletList.Add(tempBullet);
        tempBullet.GetComponent<Bullet>().Fire(Chamber);
    }
}
