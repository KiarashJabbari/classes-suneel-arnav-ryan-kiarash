using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance?.OnItemCollected();
            Destroy(gameObject);
        }
    }
}