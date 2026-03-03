using TMPro;
using UnityEngine;

public class moneytext : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private TextMeshProUGUI moneyText;
    public moneycontroller money;
    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        money = money.GetComponent<moneycontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + money.moneyGUI;
    }
}
