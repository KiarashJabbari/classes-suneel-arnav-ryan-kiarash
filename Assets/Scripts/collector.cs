using System;
using UnityEngine;

public class collector : MonoBehaviour
{

    public event Action increaseMoney;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ducky"))
        {
            increaseMoney.Invoke();
            Destroy(other.gameObject);
        }
    }
}
