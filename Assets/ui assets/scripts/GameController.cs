using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int            progressAmount;
    public Slider  progressSlider;
    public GameObject levelCompletePanel;

    // a flag so we only ever trigger completion once
    bool           _hasCompleted = false;

    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Sun.OnSunCollect += IncreaseProgressAmount;
    }

    void IncreaseProgressAmount(int amount)
    {
        if (_hasCompleted) return;

        progressAmount += amount;
        progressSlider.value = progressAmount;

        if (progressAmount >= 100)
        {
            _hasCompleted = true;
            Debug.Log("Level Complete!");

            // show the “you win” UI
            if (levelCompletePanel != null)
                levelCompletePanel.SetActive(true);

            // kick off a little pause before we actually load the next scene
            StartCoroutine(GoToNextLevelAfterDelay(1.5f));
        }
    }

    IEnumerator GoToNextLevelAfterDelay(float delay)
    {
        // wait however long you like
        yield return new WaitForSeconds(delay);

        // now actually load the correct “complete” scene
        var current = SceneManager.GetActiveScene().name;
        if (current == "Level1")
        {
            SceneManager.LoadScene("Level1Complete");
        }
        else if (current == "Level2")        // make sure this exactly matches your scene name!
        {
            SceneManager.LoadScene("Level2Complete");
        }
        else
        {
            SceneManager.LoadScene("MainMenuScreen");
        }
    }

    void OnDestroy()
    {
        Sun.OnSunCollect -= IncreaseProgressAmount;
    }
}
