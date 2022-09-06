using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panfleto : MonoBehaviour
{
    //[RequireComponent(Collider2D)]
    private void Start()
    {
        gameObject.SetActive(true);
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
