using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextAsset jsonData = Resources.Load<TextAsset>("data");
        if (jsonData != null)
        {
            string jsonString = jsonData.text;
            saveData data = JsonUtility.FromJson<saveData>(jsonString);
        }
        else
        {
            Debug.LogError("Failed to load JSON data from Resources.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
