using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuNavigator : MonoBehaviour
{
    [Header("Drag in your two menu buttons here")]
    [SerializeField] private Button loginButton;
    [SerializeField] private Button registerButton;
    [SerializeField] private string loginSceneName        = "LoginScreen";
    [SerializeField] private string registrationSceneName = "RegistrationScreen";

    private void Awake()
    {
        // sanity check:
        if (loginButton == null || registerButton == null)
        {
            Debug.LogError("Please assign the two buttons in the inspector!");
            enabled = false;
            return;
        }

        loginButton.onClick.AddListener(OnLoginClicked);
        registerButton.onClick.AddListener(OnRegisterClicked);
    }

    private void OnLoginClicked()
    {
        SceneManager.LoadScene(loginSceneName);
    }

    private void OnRegisterClicked()
    {
        SceneManager.LoadScene(registrationSceneName);
    }
}
