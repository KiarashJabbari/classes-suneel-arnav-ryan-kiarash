using UnityEngine;

public class Player : MonoBehaviour
{

    MyTime time;

    int prevSecond = 0;

    int playerX = 0;
    int playerY = 0;

    int playerVelX = 0;
    int playerVelY = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = GetComponent<MyTime>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void Move(int x, int y)
    {
        if (prevSecond != time.seconds) {
        playerX += x;
        playerY += y;
        prevSecond = time.seconds;
        }
    }

    void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1, 0);
        }
    }

    public int GetPlayerX()
    {
        return playerX;
    }

    public int GetPlayerY()
    {
        return playerY;
    }
}
