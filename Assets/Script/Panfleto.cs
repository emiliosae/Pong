using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panfleto : MonoBehaviour
{
    public int SpawnTimermin;
    public float SpawnTimersec;
    private float _timer;

    //[RequireComponent(Collider2D)]
    private void Start()
    {
        gameObject.SetActive(false);
        SpawnTimermin *= 60;
        _timer = SpawnTimermin + SpawnTimersec;
    }

    private void Update()
    {
        if (Time.time >= _timer)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().Pamflets++;
            gameObject.SetActive(false);
        }
    }
}
