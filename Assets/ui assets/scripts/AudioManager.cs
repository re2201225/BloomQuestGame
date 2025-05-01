using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private bool isMuted = false;

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;

        Debug.Log("Audio " + (isMuted ? "Muted" : "Unmuted"));
    }
}
