using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Required for TMP_InputField

public class NavigationManager : MonoBehaviour
{
    [Tooltip("Name of your main-menu scene as it appears in Build Settings")]
    public string mainMenuSceneName = "MainMenuScreen";

    [Header("Login/Register Input Fields")]
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;

    /// <summary>
    /// Call this from your Home button’s OnClick()
    /// </summary>
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }

    public void GoToMainScreen()
    {
        SceneManager.LoadScene("MainScreen", LoadSceneMode.Single);
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void GoToHomeScreen()
    {
        SceneManager.LoadScene("HomeScreen", LoadSceneMode.Single);
    }

    public void TryContinue()
    {
        if (!string.IsNullOrWhiteSpace(usernameField.text) && 
            !string.IsNullOrWhiteSpace(passwordField.text))
        {
            GoToMainScreen();
        }
        else
        {
            Debug.LogWarning("Both username and password fields must be filled.");
        }
    }
}
