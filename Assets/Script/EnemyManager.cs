using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public List<Worker> Workers = new List<Worker>();
    public List<Worker> GoodWorkers = new List<Worker>();
    public List<Protester> Rioters = new List<Protester>();
    public List<Protester> Cops = new List<Protester>();
    [SerializeField, Range(0f, 1f)] private float _winCondition;
    [SerializeField, Range(0f, 1f)] private float _riotCondition;
    [SerializeField, Range(0f, 1f)] private float _copCondition;
    private bool _noRioters;
    private bool _noCops;
    [SerializeField] private float _timer;

    void Start()
    {
        GameObject[] workers = GameObject.FindGameObjectsWithTag("Neutral");
        for (int i =0; i< workers.Length;i++)
        {
            Workers.Add(workers[i].GetComponent<Worker>());
        }
        GameObject[] rioters = GameObject.FindGameObjectsWithTag("Rioter");
        for (int i = 0; i < rioters.Length; i++)
        {
            Rioters.Add(rioters[i].GetComponent<Protester>());
        }
        GameObject[] cops = GameObject.FindGameObjectsWithTag("Cop");
        for (int i = 0; i < cops.Length; i++)
        {
            Cops.Add(cops[i].GetComponent<Protester>());
        }
    }

    void Update()
    {
        int workerPercent = (GoodWorkers.Count) / (Workers.Count);
        if (workerPercent >= _riotCondition && !_noRioters)
        {
            foreach (GameObject worker in Workers)
            {
                if (worker.GetComponent<Worker>().Spawn()) return;
            }
            GameObject worker = Instantiate(BulletPref);
            _bulletList.Add(tempBullet);
            worker.GetComponent<Worker>().Spawn();
        }
        else if(workerPercent >= _copCondition && !_noCops)
        {

        }
        else if(workerPercent >= _winCondition)
        {
            SceneManager.LoadScene("Win");
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
