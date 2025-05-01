using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private bool isMuted = false;

    [Header("Optional")]
    public Image buttonImage;         // Assign your mute button's image
    public Sprite soundOnIcon;       // Assign speaker icon
    public Sprite soundOffIcon;      // Assign muted icon

    void Start()
    {
        // Load mute state if saved previously
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        ApplyVolume();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        ApplyVolume();
    }

    void ApplyVolume()
    {
        AudioListener.volume = isMuted ? 0f : 1f;

        if (buttonImage != null)
        {
            buttonImage.sprite = isMuted ? soundOffIcon : soundOnIcon;
        }

        Debug.Log("Audio " + (isMuted ? "Muted" : "Unmuted"));
    }
}
