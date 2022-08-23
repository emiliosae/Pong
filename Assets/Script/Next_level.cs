using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_level : MonoBehaviour
{
    public void Load (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Load Level");
    }
}
