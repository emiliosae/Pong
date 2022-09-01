using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaphone : MonoBehaviour
{
    private GameObject _megaphone;
    public bool Multiplicative;
    public int DmgBuff;

    private void Start()
    {
        _megaphone.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            if (Multiplicative)
            {
                GetComponent<Bullet>().Dmg *= DmgBuff;
            }
            else
            {
                GetComponent<Bullet>().Dmg += DmgBuff;
                _megaphone.SetActive(false);
            }
        }
    }
}
