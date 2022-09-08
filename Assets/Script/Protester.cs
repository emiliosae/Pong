using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protester : Enemy
{
    public Transform Chamber;
    public GameObject BulletPref;
    List<GameObject> _bulletList = new List<GameObject>();

    public enum STATE
    {
        Running =0,
        Standing =1,
        Following =2
    }

    public STATE State = STATE.Standing;

    void Update()
    {
        _dist = Vector3.Distance(Player.transform.position, transform.position);
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
