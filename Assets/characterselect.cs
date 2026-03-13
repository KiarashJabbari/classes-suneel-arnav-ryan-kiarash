using UnityEngine;
using System;

public class characterselect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public play play;
    public float speed = 59f;
    public float targetY;
    public bool startTriggered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetY = transform.position.y + 7f;
    } 

    // Update is called once per frame
    void Update()
    {
        if(startTriggered == true && transform.position.y < targetY)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            speed = speed * 0.99f;
        }
    }

    public void characterSelection()
    {
        startTriggered = true;
    }
}
