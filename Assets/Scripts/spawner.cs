using UnityEngine;

public class spawner : MonoBehaviour
{


public GameObject duckPrefab;
public Transform spawnPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void create()
    {
        Vector3 spawnPos = spawnPoint.position;
        Instantiate(duckPrefab, spawnPos, Quaternion.identity);
    }
}

