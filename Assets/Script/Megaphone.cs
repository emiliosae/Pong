using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaphone : MonoBehaviour
{
    public bool Multiplicative;
    public int DmgBuff;
    public int SpawnTimermin;
    public float SpawnTimersec;
    private float _timer;


    private void Start()
    {
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
        if (collision.gameObject.tag == "Player" )
        {
            if (Multiplicative)
            {
                collision.GetComponent<Player>().Dmg *= DmgBuff;
                gameObject.SetActive(false);
                //Debug.Log(GetComponent<Bullet>().Dmg);
            }
            else
            {
                collision.GetComponent<Player>().Dmg += DmgBuff;
                gameObject.SetActive(false);
                //Debug.Log(GetComponent<Bullet>().Dmg);
            }
        }
    }
}
