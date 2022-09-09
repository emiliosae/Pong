using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    public List<Worker> Workers = new List<Worker>();
    public List<Worker> GoodWorkers = new List<Worker>();
    public List<Protester> Rioters = new List<Protester>();
    public List<Protester> Cops = new List<Protester>();
    [SerializeField] private int _min;
    [SerializeField] private float _sec;
    [SerializeField, Range(0f, 1f)] private float _winCondition;
    [SerializeField, Range(0f, 1f)] private float _riotCondition;
    [SerializeField, Range(0f, 1f)] private float _copCondition;
    private int _startingWorkers;
    public float workerPercent;
    //private bool _noRioters;
    //private bool _noCops;
    [SerializeField] private float _timer;
    private float _workerSpawn;
    private float _riotSpawn;
    private float _copSpawn;

    void Start()
    {
        _min *= 60;
        _timer = _min + _sec;
        _workerSpawn = 5;
        GameObject[] workers = GameObject.FindGameObjectsWithTag("Neutral");
        for (int i =0; i< workers.Length;i++)
        {
            Workers.Add(workers[i].GetComponent<Worker>());
            workers[i].gameObject.SetActive(false);
        }
        GameObject[] rioters = GameObject.FindGameObjectsWithTag("Rioter");
        for (int i = 0; i < rioters.Length; i++)
        {
            Rioters.Add(rioters[i].GetComponent<Protester>());
            rioters[i].gameObject.SetActive(false);
        }
        GameObject[] cops = GameObject.FindGameObjectsWithTag("Cop");
        for (int i = 0; i < cops.Length; i++)
        {
            Cops.Add(cops[i].GetComponent<Protester>());
            cops[i].gameObject.SetActive(false);
        }
        _startingWorkers = Workers.Count;
    }

    void Update()
    {
        workerPercent = (GoodWorkers.Count) / _startingWorkers;
        if (Time.time>= _workerSpawn)
        {
            for (int i=0; i< Workers.Count; i ++)
            {
                if (Workers[i].GetComponent<Worker>().Spawn()) break;
            }
            _workerSpawn = Time.time + Random.Range(10, 30);
        }
        SpawnRioter(workerPercent);
        SpawnCop(workerPercent);
        if (workerPercent >= _winCondition)
        {
            SceneManager.LoadScene("Win");
        }
    }

    void SpawnRioter(float workerPercent)
    {
        if (workerPercent <= _riotCondition) return;
        _riotSpawn = Time.time + Random.Range(8, 20);
        if (Time.time < _riotSpawn) return;
        foreach (Protester riot in Rioters)
        {
            if (riot.Spawn()) return;
        }
    }

    void SpawnCop(float workerPercent)
    {
        if (workerPercent < _copCondition) return;
        _copSpawn = Time.time + Random.Range(10, 25);
        if (Time.time < _copSpawn) return;
        foreach (Protester cop in Cops)
        {
            if (cop.Spawn()) return;
        }
    }

    //foreach (GameObject worker in Workers)
    //{
    //    if (bullet.GetComponent<Bullet>().Fire(Chamber)) return;
    //}
    //GameObject tempBullet = Instantiate(BulletPref);
    //_bulletList.Add(tempBullet);
    //tempBullet.GetComponent<Bullet>().Dmg = Dmg;
    //tempBullet.GetComponent<Bullet>().Fire(Chamber);

    //private void Spawn()
    //{
    //    if (this.gameObject.activeSelf) return false;
    //}
}
