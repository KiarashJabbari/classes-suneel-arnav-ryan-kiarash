using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

        TMP_Text tmpText = GetComponentInChildren<TMP_Text>();
        if (tmpText != null)
        {
            tmpText.text = "Restart";
        }
        else
        {
            Text uiText = GetComponentInChildren<Text>();
            if (uiText != null)
            {
                uiText.text = "Restart";
            }
        }

        button.onClick.RemoveListener(ButtonClicked);
        button.onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
