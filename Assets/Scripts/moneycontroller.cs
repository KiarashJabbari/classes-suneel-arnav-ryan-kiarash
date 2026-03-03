using System;
using UnityEngine;

public class moneycontroller : MonoBehaviour
{

    public int money = 0;
    public string moneyGUI;

    [SerializeField] private collector Sender;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sender.increaseMoney += IncreaseMoney;
    }

    // Update is called once per frame
    void Update()
    {
        moneyGUI = Convert.ToString(money);
    }

    void IncreaseMoney()
    {
        money++;
    }
}
