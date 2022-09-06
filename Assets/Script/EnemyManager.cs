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
        GameObject.FindGameObjectsWithTag("Good");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
