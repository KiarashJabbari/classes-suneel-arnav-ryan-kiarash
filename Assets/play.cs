using UnityEngine;
using System;

public class play : MonoBehaviour
{

    public event Action characterSelect;
    public SpriteRenderer spriteRenderer;
    public float speed = 5f;
    public float targetY;
    public bool startTriggered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetY = transform.position.y + 10f;
    } 

    // Update is called once per frame
    void Update()
    {
        if(startTriggered == true && transform.position.y < targetY)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            speed = speed * 1.01f;
        }
    }

    public void onStart()
    {
        startTriggered = true;
    }
}
