using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static float Money;
    public float Startmoney = 1000;

    public static int Lives;
    public int Startinglives = 10;

    public static int Rounds;


    private void Start()
    {
        Money = Startmoney;
        Lives = Startinglives;
        Rounds = 0;
    }


}
