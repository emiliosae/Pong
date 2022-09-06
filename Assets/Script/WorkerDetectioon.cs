using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkerDetectioon : MonoBehaviour
{
    public GameObject Player;
    public int Enemies;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            Enemies++;
            Player.GetComponent<Player>().HP -- ;
            //if (Enemies>= Player.GetComponent<Player>().HP)
            //{
            //    SceneManager.LoadScene("Lose");
            //}
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            Enemies--;
            Player.GetComponent<Player>().HP++;
        }
    }
}
