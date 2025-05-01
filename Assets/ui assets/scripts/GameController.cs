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
    public GameObject levelCompletePanel; // ✅ ADD THIS

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

            SceneManager.LoadScene("LevelComplete"); // Replace with your actual scene name

        }
    }

    void Update()
    {
        
    }
}
