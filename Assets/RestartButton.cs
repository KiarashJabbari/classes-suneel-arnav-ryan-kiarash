using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.LogError("RestartButton requires a Unity UI Button component on the same GameObject.");
            return;
        }

        button.onClick.RemoveListener(ButtonClicked);
        button.onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
