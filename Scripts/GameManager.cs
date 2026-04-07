using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TMP_Text itemCountText;
    public GameObject levelCompletePanel;
    public GameObject retryPanel;

    private int _totalItems;
    private int _collectedItems;
    private bool _levelEnded;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        _totalItems = FindObjectsOfType<CollectibleItem>().Length;
        _collectedItems = 0;
        _levelEnded = false;

        levelCompletePanel?.SetActive(false);
        retryPanel?.SetActive(false);

        UpdateUI();
    }

    public void OnItemCollected()
    {
        if (_levelEnded) return;
        _collectedItems++;
        UpdateUI();
        if (_collectedItems >= _totalItems)
            StartCoroutine(LevelCompleteAfterMove());
    }

    public void OnPlayerDeath()
    {
        if (_levelEnded) return;
        _levelEnded = true;
        retryPanel?.SetActive(true);
        Time.timeScale = 0f;
    }

    System.Collections.IEnumerator LevelCompleteAfterMove()
    {
        _levelEnded = true;
        var player = FindObjectOfType<PlayerController>();
        while (player != null && player.IsMoving)
            yield return null;
        levelCompletePanel?.SetActive(true);
        Time.timeScale = 0f;
    }

    void UpdateUI()
    {
        if (itemCountText != null)
            itemCountText.text = $"{_collectedItems} / {_totalItems}";
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}