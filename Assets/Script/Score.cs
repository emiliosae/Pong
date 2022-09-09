using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text WinPercentage;
    public GameObject Cosas;

    private void Update()
    {
        WinPercentage.text = $"{Cosas.GetComponent<EnemyManager>().workerPercent*100} %";
    }
}
