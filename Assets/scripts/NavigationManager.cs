using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    [Tooltip("Name of your main-menu scene as it appears in Build Settings")]
    public string mainMenuSceneName = "MainMenu_Screen";

    /// <summary>
    /// Call this from your Home button’s OnClick()
    /// </summary>
    public void GoToMainMenu()
    {
        // you could also use LoadSceneAsync if you like
        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }
}
