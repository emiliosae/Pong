using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaphone : MonoBehaviour
{
    public bool Multiplicative;
    public int DmgBuff;

    //private void Start()
    //{
    //    gameObject.SetActive(true);
    //}

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
