using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Worker> Workers = new List<Worker>();
    public List<Worker> GoodWorkers = new List<Worker>();
    public List<Protester> Protesters = new List<Protester>();
    public List<Protester> Cops = new List<Protester>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] workers = GameObject.FindGameObjectsWithTag("Good");
        for (int i =0; i< workers.Length;i++)
        {
            Workers.Add(workers[i].GetComponent<Worker>());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
