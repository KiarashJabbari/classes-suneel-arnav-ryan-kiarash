using UnityEngine;

public class playerbuttoncontrol : MonoBehaviour
{
    public GameObject player1button;
    public GameObject player2button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1button.SetActive(false);
        player2button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStart()
    {
        player1button.SetActive(true);
        player2button.SetActive(true);
    }
}
