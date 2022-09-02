using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panfleto : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
                GetComponent<Player>().Pamflets ++;
                gameObject.SetActive(false);
        }
    }
}
