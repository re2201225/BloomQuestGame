using UnityEngine;

public class PersistentAudio : MonoBehaviour
{
    private static PersistentAudio instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); // Already exists
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep across scenes
            GetComponent<AudioSource>().Play();
        }
    }
}
