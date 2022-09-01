using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : Enemy
{
    public enum BANDO
    {
        Good = 0,
        Neutral = 1,
        Bad = 2
    }

    public BANDO Bando;

    void Start()
    {
        CurrentHp = MaxHp;
    }

    private void Update()
    {
        //switch (Bando)
        //{

        //}
    }
}
