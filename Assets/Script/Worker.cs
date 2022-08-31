using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : Enemy
{
    public enum Bando
    {
        Good = 0,
        Neutral = 1,
        Bad = 2
    }

    void Start()
    {
        CurrentHp = MaxHp;
    }

    public void TakeDmg(int dmg)
    {
        CurrentHp -= dmg;

        if (CurrentHp <= 0)
        {
            //cambio de bando
        }
    }
}
