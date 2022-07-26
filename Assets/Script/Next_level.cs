using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next_level : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Load Level");
    }
}
