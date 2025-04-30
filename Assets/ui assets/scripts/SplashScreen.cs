using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
    [Tooltip("Name of the scene to open after the splash")]
    [SerializeField] private string _nextSceneName = "MainMenu_Screen";
    
    [Tooltip("How many seconds to wait on the splash screen")]
    [SerializeField] private float _displayDuration = 2f;

    private void Start()
    {
        // kick off the timer as soon as this object awakes
        StartCoroutine(GoToMainMenuAfterDelay());
    }

    private IEnumerator GoToMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(_displayDuration);
        SceneManager.LoadScene(_nextSceneName);
    }
}
