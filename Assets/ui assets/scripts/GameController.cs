using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;
    public GameObject levelCompletePanel;

    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Sun.OnSunCollect += IncreaseProgressAmount;
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;

        if (progressAmount >= 100)
        {
            Debug.Log("Level Complete!");

            if (levelCompletePanel != null)
                levelCompletePanel.SetActive(true);

            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Level1")
            {
                SceneManager.LoadScene("Level1Complete");
            }
            else if (currentScene == "LevelTW0")
            {
                SceneManager.LoadScene("Level2Complete");
            }
            else
            {
                SceneManager.LoadScene("HomeScreen"); // fallback
            }
        }
    }

    void Update()
    {
        
    }
}
