using UnityEngine;

public class PlayerCharacter : MonoBehaviour

    {
    Collider2D playerCollider;
    Rigidbody2D Rigidbody2D;
    MyTime time;
    int prevSecond = 0;

    float playerVelX = 0f;
    float playerVelY = 0f;
    float playerVel = 3f; // units per second
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {
            time = GetComponent<MyTime>();
            playerCollider = GetComponent<Collider2D>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Rigidbody2D.position = new Vector2(-10.37f, 3.74f);
        }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Move();
    }

    void Move()
    {
        Rigidbody2D.linearVelocity = new Vector2(playerVelX, playerVelY);
        prevSecond = time.seconds;
    }

    void OnCollisionEnter2D (Collision2D collision)
        {
            playerVelX = 0f;
            playerVelY = 0f;
            Debug.Log("Collided");
        }

    void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerVelY = playerVel;
            playerVelX = 0f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerVelY = -playerVel;
            playerVelX = 0f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerVelX = -playerVel;
            playerVelY = 0f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerVelX = playerVel;
            playerVelY = 0f;
        }
    }

    public float GetPlayerX()
    {
        return transform.position.x;
    }

    public float GetPlayerY()
    {
        return transform.position.y;
    }
}
