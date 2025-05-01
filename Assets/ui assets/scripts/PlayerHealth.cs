using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public List<Image> heartIcons;    // Drag your 3 UI hearts here
    public Sprite heartFull;
    public Sprite heartEmpty;
    public int maxHearts = 3;
    public float damageCooldown = 1f; // Seconds before player can take damage again

    private int currentHearts;
    private bool isInvulnerable = false;

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
        if (isInvulnerable || currentHearts <= 0) return;

        currentHearts--;
        UpdateHeartsUI();

        // Optional animation trigger
        var anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.Play("YoungVersion");
        }

        if (currentHearts == 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(DamageCooldown());
        }
    }

    System.Collections.IEnumerator DamageCooldown()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(damageCooldown);
        isInvulnerable = false;
    }

    void Die()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
