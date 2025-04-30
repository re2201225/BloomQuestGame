using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public List<Image> heartIcons;    // drag your 3 UI hearts here
    public Sprite heartFull;          // your red heart sprite
    public Sprite heartEmpty;         // (optional) grey heart for “lost”
    public int maxHearts = 3;

    int currentHearts;

    void Start()
    {
        currentHearts = maxHearts;
        UpdateHeartsUI();
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < heartIcons.Count; i++)
        {
            heartIcons[i].sprite = i < currentHearts ? heartFull : heartEmpty;
        }
    }

    public void TakeDamage()
    {
        if (currentHearts <= 0) return;
        currentHearts--;
        UpdateHeartsUI();
        // TODO: swap to “younger” animation here
        var anim = GetComponent<Animator>();
        anim.Play("YoungVersion"); 
        if (currentHearts == 0)
        {
            Die();
        }
    }

    public void GrowUp()
    {
        if (currentHearts >= maxHearts) return;
        currentHearts++;
        UpdateHeartsUI();
        // TODO: swap to “older” animation here
        var anim = GetComponent<Animator>();
        anim.Play("OlderVersion");
    }

    void Die()
    {
        // e.g. reload scene or show Game Over
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomeScreen");
    }
}
